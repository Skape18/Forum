using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.DTOs;
using BLL.Interfaces;
using Forum.ViewModels;
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
        

        [HttpPut("deactivate/{userId}")]
        public async Task<IActionResult> Deactivate(int userId)
        {
            var isSuccessful = await _userService.Deactivate(userId);

            if (!isSuccessful)
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        [Route("upload-image/{userId}")]
        public async Task<IActionResult> UploadImage([FromRoute]int userId, [FromForm] ImageViewModel userImage)
        {
            string imageName = Path.GetFileNameWithoutExtension(userImage.UserImage.FileName) + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(userImage.UserImage.FileName);

            string imagePath = Path.Combine("profile_images", imageName);

            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, imagePath);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await userImage.UserImage.CopyToAsync(stream);
            }

            await _userService.UpdateImagePath(userId, imagePath);

            return Ok();
        }
    }
}
