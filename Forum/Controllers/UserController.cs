using System;
using System.Collections.Generic;
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

        [HttpPut("{userId}")]
        public async Task<IActionResult> Update(
            [FromRoute]int userId,
            [FromBody] UserUpdateViewModel updateViewModel)
        {
            await _userService.Update(userId, updateViewModel.TagIds, updateViewModel.Description);

            return Ok();
        }

        [HttpPut("{userId}/likes/{likeBy}")]
        public async Task<IActionResult> LikeUser(
            [FromRoute]int userId,
            [FromRoute]int likeBy)
        {
            await _userService.Like(likeBy, userId);

            return Ok();
        }

        [HttpDelete("{userId}/likes/{likeBy}")]
        public async Task<IActionResult> RemoveLikeFromUser(
            [FromRoute]int userId,
            [FromRoute]int likeBy)
        {
            await _userService.Unlike(likeBy, userId);

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

        [Authorize]
        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> Search(
            [FromQuery(Name = "searchTerm")] string search)
        {
            var userDtos = await _userService.Search(search);
            var userViewModel = _mapper.Map<IEnumerable<UserDto>, IEnumerable<UserViewModel>>(userDtos);

            return Ok(userViewModel);
        }
    }
}
