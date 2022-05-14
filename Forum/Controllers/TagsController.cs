using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using DAL.Domain.Entities;
using Forum.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService, IMapper mapper)
        {
            _mapper = mapper;
            _tagService = tagService;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagViewModel>>> Get()
        {
            var tags  = await _tagService.GetAllAsync();
            var postViewModels = _mapper.Map<IEnumerable<Tag>, List<TagViewModel>>(tags);

            return Ok(postViewModels);
        }
    }
}