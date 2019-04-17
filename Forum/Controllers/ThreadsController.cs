using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.DTOs;
using BLL.Interfaces;
using Forum.ViewModels.ThreadViewModel;
using Microsoft.AspNetCore.Authorization;
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
        

        // GET: api/Threads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThreadDisplayViewModel>>> Get()
        {
            var threadDtos = await _threadService.GetAllAsync();

            var threadViewModels = _mapper.Map<IEnumerable<ThreadDto>, List<ThreadDisplayViewModel>>(threadDtos);

            return Ok(threadViewModels);
        }
        
        // GET: api/Threads/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ThreadDisplayViewModel>> Get(int id)
        {
            var threadDto = await _threadService.GetByIdAsync(id);

            if (threadDto == null)
                return BadRequest();

            var threadViewModel = _mapper.Map<ThreadDto, ThreadDisplayViewModel>(threadDto);

            return Ok(threadViewModel);
        }

        //GET api/topics/4/threads"
        [HttpGet]
        [Route("~/api/topics/{topicId:int}/threads")]
        public async Task<ActionResult<IEnumerable<ThreadDisplayViewModel>>> GetThreadsByTopicId(int topicId)
        {
            var threadDtos = await _threadService.GetThreadsByTopicId(topicId);

            if (threadDtos == null)
                return BadRequest();

            var threadViewModels = _mapper.Map<IEnumerable<ThreadDto>, List<ThreadDisplayViewModel>>(threadDtos);
            return Ok(threadViewModels);
        }

        // POST: api/Threads
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post([FromBody] CreateThreadViewModel threadViewModel)
        {
            var threadDto = _mapper.Map<CreateThreadViewModel, ThreadDto>(threadViewModel);

            await _threadService.CreateAsync(threadDto);

            return Ok();
        }

        [Authorize]
        // DELETE: api/Threads/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var threadDto = await _threadService.GetByIdAsync(id);

            if (threadDto == null)
                return BadRequest();

            await _threadService.RemoveAsync(threadDto);

            return Ok();
        }


        // PUT: api/User/5
        [Authorize(Roles = "Admin")]
        [HttpPut("deactivate/{threadId}")]
        public async Task<IActionResult> Deactivate(int threadId)
        {
            var isSuccessful = await _threadService.Deactivate(threadId);

            if (!isSuccessful)
                return BadRequest();

            return Ok(); 
        }
    }
}
