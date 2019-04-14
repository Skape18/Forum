using System;
using System.IO;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;
        private IUserService _userService;
        private ITopicService _topicService;

        public ImageController(IHostingEnvironment hostingEnvironment, IUserService userService, ITopicService topicService)
        {
            _hostingEnvironment = hostingEnvironment;
            _userService = userService;
            _topicService = topicService;
        }

       
        // POST: api/Image
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Image/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
         
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
