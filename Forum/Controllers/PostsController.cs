using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.DTOs;
using BLL.Interfaces;
using Forum.ViewModels.PostViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public IPostService PostService { get; }
        public IUserService UserService { get; }
        public IMapper Mapper { get; }
        
        public PostsController(IPostService postService, IUserService userService, IMapper mapper)
        {
            PostService = postService;
            Mapper = mapper;
            UserService = userService;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisplayPostViewModel>>> Get()
        {
            var postsDto  = await PostService.GetAllAsync();
            var postViewModels = Mapper.Map<IEnumerable<PostDto>, List<DisplayPostViewModel>>(postsDto);

            foreach (var postViewModel in postViewModels)
            {
                postViewModel.UserProfile.IsAdmin =
                    await UserService.IsUserInRole(postViewModel.UserProfile.UserName, "admin");
            }

            return Ok(postViewModels);
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisplayPostViewModel>> Get(int id)
        {
            var postDto = await PostService.GetByIdAsync(id);

            if (postDto == null)
                return BadRequest();

            var postViewModel = Mapper.Map<PostDto, DisplayPostViewModel>(postDto);
            postViewModel.UserProfile.IsAdmin =
                await UserService.IsUserInRole(postViewModel.UserProfile.UserName, "admin");
            
            return Ok(postViewModel);
        }

        // POST: api/Posts
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatePostViewModel createPostView)
        {
            var postDto = Mapper.Map<CreatePostViewModel, PostDto>(createPostView);
            await PostService.CreateAsync(postDto);

            return Ok();
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        //[Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var postDto = await PostService.GetByIdAsync(id);

            if (postDto == null)
                return BadRequest();

            await PostService.RemoveAsync(id);

            return Ok();
        }


    }
}
