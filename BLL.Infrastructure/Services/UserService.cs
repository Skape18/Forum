using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.DTOs;
using BLL.Interfaces;
using DAL.Domain.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BLL.Infrastructure.Services
{
    public class UserService : BaseService, IUserService
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private string _defaultProfileImagePath;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
                            IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _defaultProfileImagePath = "profile_images/default_profile_image.png";
        }

        

        public async Task<bool> IsUserInRole(string userName, string role)
        {
            ApplicationUser user = null;

            var userProfiles = await UnitOfWork.UserProfiles.GetAllAsync();
            
            foreach (var userProfile in userProfiles)
            {
                if (userProfile.ApplicationUser.UserName == userName)
                {
                    user = userProfile.ApplicationUser;
                    break;
                }
            }

            if (user != null)
                return await _userManager.IsInRoleAsync(user, role);

            return false;
        }

        public async Task<ICollection<string>> GetRoles(int userId)
        {
            var user = await UnitOfWork.UserProfiles.GetByIdAsync(userId);

            if (user != null)
                return await _userManager.GetRolesAsync(user.ApplicationUser);

            return null;
        }

        public async Task<SignedInUserDto> SignIn(LoginDto loginDto, string tokenKey, int tokenLifetime, string tokenAudience, string tokenIssuer)
        {
            if (loginDto == null)
                return null;

            var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);

            if (!result.Succeeded)
                return null;

            var user = await _userManager.FindByNameAsync(loginDto.UserName);

            string token = GenerateJWTToken(user, tokenKey, tokenLifetime, tokenAudience, tokenIssuer);

            var userProfiles = await UnitOfWork.UserProfiles.GetAllAsync();
            var userProfile = userProfiles.FirstOrDefault(up => up.ApplicationUserId == user.Id);

            if (userProfile == null)
                return null;
            
            var userDto = Mapper.Map<UserProfile, UserDto>(userProfile);

            return new SignedInUserDto(userDto, token);
        }

        public async Task<SignedInUserDto> SignUp(RegistrationDto registrationDto, string tokenKey, int tokenLifetime, string tokenAudience, string tokenIssuer)
        {
            if (registrationDto == null)
                return null;

            var applicationUser = Mapper.Map<RegistrationDto, ApplicationUser>(registrationDto);
            
            var result = await _userManager.CreateAsync(applicationUser, registrationDto.Password);

            if (!result.Succeeded)
            {
                string errors = "";
                foreach (var identityError in result.Errors)
                {
                    errors += $"{identityError.Description}\n";
                }
                throw new Exception(errors);
            }

            await UnitOfWork.SaveChangesAsync();

            var userProfile = new UserProfile
            {
                ApplicationUserId = applicationUser.Id,
                IsActive = true,
                Rating = 0,
                RegistrationDate = DateTime.Now,
                ProfileImagePath = registrationDto.ProfileImagePath ?? _defaultProfileImagePath
            };

            await UnitOfWork.UserProfiles.CreateAsync(userProfile);
            await UnitOfWork.SaveChangesAsync();

            //For mapping
            userProfile.ApplicationUser = applicationUser;

            await _signInManager.SignInAsync(applicationUser, false);
          
            string token = GenerateJWTToken(applicationUser, tokenKey, tokenLifetime, tokenAudience, tokenIssuer);
            var userDto = Mapper.Map<UserProfile, UserDto>(userProfile);

            return new SignedInUserDto(userDto, token);
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserDto> GetUserDetails(int userId)
        {
            var userProfile = await UnitOfWork.UserProfiles.GetByIdAsync(userId);

            if (userProfile == null)
                return null;

            var userDto = Mapper.Map<UserProfile, UserDto>(userProfile);

            return userDto;
        }

        private string GenerateJWTToken(ApplicationUser user, string tokenKey, int tokenLifetime, string tokenAudience, string tokenIssuer)
        {
            var utcNow = DateTime.UtcNow;

            var claims = new []
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString())
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                notBefore: utcNow,
                expires: utcNow.AddMinutes(tokenLifetime),
                audience: tokenAudience,
                issuer: tokenIssuer
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
