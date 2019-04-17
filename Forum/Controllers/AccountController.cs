using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.DTOs;
using BLL.Interfaces;
using Forum.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AccountController(IUserService userService, IMapper mapper, IConfiguration configuration)
        {
            _userService = userService;
            _mapper = mapper;
            _configuration = configuration;
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<SignedInUserViewModel>> Login([FromBody]LoginViewModel loginViewModel)
        {
            var loginDto = _mapper.Map<LoginViewModel, LoginDto>(loginViewModel);

            var signedInUser = await _userService.SignInAsync(loginDto, _configuration["Tokens:Key"],
                int.Parse(_configuration["Tokens:ExpiryMinutes"]),
                _configuration["Tokens:Audience"], _configuration["Tokens:Issuer"]
            );

            var signedInUserViewModel = _mapper.Map<SignedInUserDto, SignedInUserViewModel>(signedInUser);


            return Ok(signedInUserViewModel);
        }
        
        [HttpPost("registration")]
        public async Task<ActionResult<SignedInUserViewModel>> Register([FromBody]RegistrationViewModel registrationViewModel)
        {
            var registrationDto = _mapper.Map<RegistrationViewModel, RegistrationDto>(registrationViewModel);

            var signedInUser = await _userService.SignUpAsync(registrationDto, _configuration["Tokens:Key"],
                int.Parse(_configuration["Tokens:ExpiryMinutes"]),
                _configuration["Tokens:Audience"], _configuration["Tokens:Issuer"]
            );

            var signedInUserViewModel = _mapper.Map<SignedInUserDto, SignedInUserViewModel>(signedInUser);

            return Ok(signedInUserViewModel);
        }
        
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _userService.SignOutAsync();

            return Ok();
        }

        [HttpGet("is-admin")]
        public async Task<ActionResult<bool>> IsAdmin(int userId)
        {
            var isAdmin = await _userService.IsUserInRoleAsync(userId, "admin");

            return Ok(isAdmin);
        }
    }
}
