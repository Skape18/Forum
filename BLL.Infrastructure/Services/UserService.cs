using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.DTOs;
using BLL.Interfaces;
using BLL.Infrastructure.Exceptions;
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
        private ITagService _tagService;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
                            IUnitOfWork unitOfWork, IMapper mapper, ITagService tagService) : base(unitOfWork, mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tagService = tagService;
            _defaultProfileImagePath = "profile_images/default_profile_image.png";
        }

        
        public async Task<bool> IsUserInRoleAsync(int id, string role)
        {
            var user = await UnitOfWork.UserProfiles.GetByIdAsync(id);

            if (user == null)
                throw new DbQueryResultNullException("Db query result is null", "user profiles");

            return await _userManager.IsInRoleAsync(user.ApplicationUser, role); 
        }

        public async Task<ICollection<string>> GetRolesAsync(int userId)
        {
            var user = await UnitOfWork.UserProfiles.GetByIdAsync(userId);

            if (user == null)
                throw new DbQueryResultNullException("Db query result is null", "user profiles");

            return await _userManager.GetRolesAsync(user.ApplicationUser);
        }

        public async Task<SignedInUserDto> SignInAsync(LoginDto loginDto, string tokenKey, int tokenLifetime, string tokenAudience, string tokenIssuer)
        {
            if (loginDto == null)
                throw new ArgumentNullException("loginDto", "Login dto argument is null");

            var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);

            if (!result.Succeeded)
                throw new UserLogInException("Failed to sign in user"); 

            var user = await _userManager.FindByNameAsync(loginDto.UserName);

            string token = await GenerateJWTToken(user, tokenKey, tokenLifetime, tokenAudience, tokenIssuer);

            var userProfiles = await UnitOfWork.UserProfiles.GetAllAsync();
            var userProfile = userProfiles.FirstOrDefault(up => up.ApplicationUserId == user.Id);

            if (userProfile == null)
                throw new DbQueryResultNullException("Db query result is null", "user profiles");

            var userDto = Mapper.Map<UserProfile, UserDto>(userProfile);

            return new SignedInUserDto(userDto, token);
        }

        public async Task<SignedInUserDto> SignUpAsync(RegistrationDto registrationDto, string tokenKey, int tokenLifetime, string tokenAudience, string tokenIssuer)
        {
            if (registrationDto == null)
                throw new ArgumentNullException();

            var applicationUser = Mapper.Map<RegistrationDto, ApplicationUser>(registrationDto);
            
            var result = await _userManager.CreateAsync(applicationUser, registrationDto.Password);

            if (!result.Succeeded)
                throw new UserCreationException("Failed to create user");

            await UnitOfWork.SaveChangesAsync();

            var userProfile = new UserProfile
            {
                ApplicationUserId = applicationUser.Id,
                IsActive = true,
                RegistrationDate = DateTime.Now,
                ProfileImagePath = registrationDto.ProfileImagePath ?? _defaultProfileImagePath
            };

            await UnitOfWork.UserProfiles.CreateAsync(userProfile);
            await UnitOfWork.SaveChangesAsync();

            //For mapping
            userProfile.ApplicationUser = applicationUser;

            await _signInManager.SignInAsync(applicationUser, false);
          
            string token = await GenerateJWTToken(applicationUser, tokenKey, tokenLifetime, tokenAudience, tokenIssuer);

            var userDto = Mapper.Map<UserProfile, UserDto>(userProfile);

            return new SignedInUserDto(userDto, token);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserDto> GetUserDetailsAsync(int userId)
        {
            var userProfile = await UnitOfWork.UserProfiles.GetByIdAsync(userId);

            if (userProfile == null)
                throw new DbQueryResultNullException("Db query result is null", "user profiles");

            var userDto = Mapper.Map<UserProfile, UserDto>(userProfile);

            return userDto;
        }

        public async Task<bool> Deactivate(int userId)
        {
            var user = await UnitOfWork.UserProfiles.GetByIdAsync(userId);

            if (user == null)
                throw new DbQueryResultNullException("Db query result is null", "user profiles");

            user.IsActive = false;

            UnitOfWork.UserProfiles.Update(user);
            await UnitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task UpdateImage(int userId, string fileName, string rootPath, byte[] image)
        {
            var user = await UnitOfWork.UserProfiles.GetByIdAsync(userId);

            string imageName = Path.GetFileNameWithoutExtension(fileName) + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(fileName);

            var profileImagePath = Path.Combine("profile_images", imageName);

            user.ProfileImagePath = profileImagePath;

            var fullPath = Path.Combine(rootPath, profileImagePath);

            await File.WriteAllBytesAsync(fullPath, image);

            UnitOfWork.UserProfiles.Update(user);

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateTags(int userId, IEnumerable<int> tagIds)
        {
            var user = await UnitOfWork.UserProfiles.GetByIdAsync(userId);
            var tags = await _tagService.GetAllAsync();

            foreach (var tagId in tagIds)
            {
                if (user.Tags.All(t => t.Id != tagId))
                {
                    var tag = tags.First(t => t.Id == tagId);
                    user.Tags.Add(tag);
                }
            }

            UnitOfWork.UserProfiles.Update(user);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task Unlike(int likeBy, int userId)
        {
            var user = await UnitOfWork.UserProfiles.GetByIdAsync(userId);

            if (user.LikedBy.All(u => u.Id != likeBy))
                return;

            var likedByUser = await UnitOfWork.UserProfiles.GetByIdAsync(likeBy);
            user.LikedBy.Remove(likedByUser);
            user.Rating--;

            UnitOfWork.UserProfiles.Update(user);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task Like(int likeBy, int userId)
        {
            var user = await UnitOfWork.UserProfiles.GetByIdAsync(userId);

            if (user.LikedBy.Any(u => u.Id == likeBy))
                return;

            var likedByUser = await UnitOfWork.UserProfiles.GetByIdAsync(likeBy);
            user.LikedBy.Add(likedByUser);
            user.Rating++;

            UnitOfWork.UserProfiles.Update(user);
            await UnitOfWork.SaveChangesAsync();
        }

        private async Task<string> GenerateJWTToken(ApplicationUser user, string tokenKey, int tokenLifetime, string tokenAudience, string tokenIssuer)
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

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);

            var roles = await _userManager.GetRolesAsync(user);

            claimsIdentity.AddClaims(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claimsIdentity.Claims,
                notBefore: utcNow,
                expires: utcNow.AddMinutes(tokenLifetime),
                audience: tokenAudience,
                issuer: tokenIssuer
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
