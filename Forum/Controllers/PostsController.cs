using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.DTOs;
using BLL.Interfaces;
using Forum.ViewModels.PostViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        
        public PostsController(IPostService postService, IUserService userService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
            _userService = userService;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDisplayViewModel>>> Get()
        {
            var postDtos  = await _postService.GetAllAsync();
            var postViewModels = _mapper.Map<IEnumerable<PostDto>, List<PostDisplayViewModel>>(postDtos);

            return Ok(postViewModels);
        }

        // GET: api/Posts/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PostDisplayViewModel>> Get(int id)
        {
            var postDto = await _postService.GetByIdAsync(id);

            if (postDto == null)
                return BadRequest();

            var postViewModel = _mapper.Map<PostDto, PostDisplayViewModel>(postDto);
            
            return Ok(postViewModel);
        }


        //GET: api/threads/4/posts
        [HttpGet]
        [Route("~/api/threads/{threadId}/posts")]
        public async Task<ActionResult<IEnumerable<PostDisplayViewModel>>> GetPostsByThreadId(int threadId)
        {
            var postDtos = await _postService.GetPostsByThreadTitle(threadId);

            if (postDtos == null)
                return BadRequest();

            var postViewModels = _mapper.Map<IEnumerable<PostDto>, List<PostDisplayViewModel>>(postDtos);

            return Ok(postViewModels);
        }


        // POST: api/Posts
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CreatePostViewModel createPostView)
        {
            var postDto = _mapper.Map<CreatePostViewModel, PostDto>(createPostView);
            await _postService.CreateAsync(postDto);

            return Ok();
        }
        

        //DELETE: api/Posts/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var postDto = await _postService.GetByIdAsync(id);

            if (postDto == null)
                return BadRequest();

            await _postService.RemoveAsync(postDto);

            return Ok();
        }
    }
}
