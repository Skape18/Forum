using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.DTOs;
using BLL.Interfaces;
using Forum.ViewModels.PostViewModels;
using Forum.ViewModels.ThreadViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadsController : ControllerBase
    {
        private readonly IThreadService _threadService;
        private readonly IMapper _mapper;

        public ThreadsController(IThreadService threadService, IMapper mapper)
        {
            _threadService = threadService;
            _mapper = mapper;
        }
        
        [HttpGet("{threadId}/posts")]
        public async Task<ActionResult<IEnumerable<PostDisplayViewModel>>> GetThreadPosts(int threadId)
        {
            var threadDto = await _threadService.GetByIdAsync(threadId);

            if (threadDto == null)
                return BadRequest();

            var postViewModels = _mapper.Map<IEnumerable<PostDto>, List<PostDisplayViewModel>>(threadDto.Posts);

            return Ok(postViewModels);
        }

        // GET: api/Threads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThreadDisplayViewModel>>> Get()
        {
            var threadDtos = await _threadService.GetAllAsync();

            var threadViewModels = _mapper.Map<IEnumerable<ThreadDto>, List<ThreadDisplayViewModel>>(threadDtos);

            return Ok(threadViewModels);
        }
        
        // GET: api/Threads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThreadDisplayViewModel>> Get(int id)
        {
            var threadDto = await _threadService.GetByIdAsync(id);

            if (threadDto == null)
                return BadRequest();

            var threadViewModel = _mapper.Map<ThreadDto, ThreadDisplayViewModel>(threadDto);

            return Ok(threadViewModel);
        }

        // POST: api/Threads
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateThreadViewModel threadViewModel)
        {
            var threadDto = _mapper.Map<CreateThreadViewModel, ThreadDto>(threadViewModel);

            await _threadService.CreateAsync(threadDto);

            return Ok();
        }

        // DELETE: api/Threads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var threadDto = await _threadService.GetByIdAsync(id);

            if (threadDto == null)
                return BadRequest();

            await _threadService.RemoveAsync(threadDto);

            return Ok();
        }
    }
}
