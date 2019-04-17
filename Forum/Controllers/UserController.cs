using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.DTOs;
using BLL.Interfaces;
using Forum.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        private IHostingEnvironment _hostingEnvironment;

        private IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _userService = userService;
            _mapper = mapper;
        }  


        // GET: api/User/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserViewModel>> Get(int id)
        {
            var userDto = await _userService.GetUserDetailsAsync(id);
            if (userDto == null)
                return BadRequest();
            var userViewModel = _mapper.Map<UserDto, UserViewModel>(userDto);

            return Ok(userViewModel);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPut("deactivate/{userId}")]
        public async Task<IActionResult> Deactivate(int userId)
        {
            var isSuccessful = await _userService.Deactivate(userId);

            if (!isSuccessful)
                return BadRequest();

            return Ok();
        }

        [Authorize]
        [HttpPut]
        [Route("upload-image/{userId}")]
        public async Task<IActionResult> UploadImage([FromRoute]int userId, [FromForm] ImageViewModel userImage)
        {
            byte[] fileBytes;

            using (var stream = new MemoryStream())
            {
                await userImage.UserImage.CopyToAsync(stream);
                fileBytes = stream.ToArray();
            }
            
            await _userService.UpdateImage(userId, userImage.UserImage.FileName, _hostingEnvironment.WebRootPath, fileBytes);

            return Ok();
        }
    }
}
