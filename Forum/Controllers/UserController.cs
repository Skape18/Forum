
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.DTOs;
using BLL.Interfaces;
using Forum.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        private IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
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

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
