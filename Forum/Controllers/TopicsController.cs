using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.DTOs;
using BLL.Interfaces;
using Forum.ViewModels.TopicViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostingEnvironment;

        public TopicsController(ITopicService topicService, IMapper mapper, IHostingEnvironment hostingEnvironment)
        {
            _topicService = topicService;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        
        // GET: api/Topics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicViewModel>>> Get()
        {
            var topicDtos = await _topicService.GetAllAsync();
            var topicViewModels = _mapper.Map<IEnumerable<TopicDto>, List<TopicViewModel>>(topicDtos);

            return Ok(topicViewModels);
        }

        // GET: api/Topics/1
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<TopicViewModel>>> Get(int id)
        {
            var topicDto = await _topicService.GetByIdAsync(id);

            if (topicDto == null)
                return BadRequest();

            var topicViewModel = _mapper.Map<TopicDto, TopicViewModel>(topicDto);

            return Ok(topicViewModel);
        }


        // POST: api/Topics
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateTopicViewModel topicViewModel)
        {
            if (topicViewModel == null)
                throw new Exception("empty topic view model");

            if (topicViewModel.Image == null)
                throw new Exception("image is empty");


            var topicDto = _mapper.Map<CreateTopicViewModel, TopicDto>(topicViewModel);

            string imageName = Path.GetFileNameWithoutExtension(topicViewModel.Image.FileName) + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(topicViewModel.Image.FileName);

            string imagePath = Path.Combine("topic_images", imageName);

            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, imagePath);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await topicViewModel.Image.CopyToAsync(stream);
            }

            topicDto.ImagePath = imagePath;

            await _topicService.CreateAsync(topicDto);

            return Ok();
        }

        // PUT: api/Topics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TopicViewModel topicViewModel)
        {
            var topicDto = await _topicService.GetByIdAsync(id);

            if (topicDto == null)
                return BadRequest();

            topicDto = _mapper.Map<TopicViewModel, TopicDto>(topicViewModel);

            await _topicService.UpdateAsync(topicDto);
            return Ok();
        }

        // DELETE: api/Topics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var topicDto = await _topicService.GetByIdAsync(id);

            if (topicDto == null)
                return BadRequest();

            await _topicService.RemoveAsync(topicDto);

            return Ok();
        }
    }
}
