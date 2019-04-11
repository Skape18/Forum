using System.Collections.Generic;
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
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public NotificationsController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }


        // GET: api/Notifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationViewModel>>> Get()
        {
            var notificationDtos = await _notificationService.GetAllAsync();

            var notificationViewModels = _mapper.Map<IEnumerable<NotificationDto>, List<NotificationViewModel>>
                (notificationDtos);

            return Ok(notificationViewModels);
        }
        
        // POST: api/Notifications
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] NotificationViewModel notificationViewModel)
        {
            if (notificationViewModel == null)
                return BadRequest();

            var notificationDto = _mapper.Map<NotificationViewModel, NotificationDto>(notificationViewModel);

            await _notificationService.CreateAsync(notificationDto);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var notificationDto = await _notificationService.GetByIdAsync(id);

            if (notificationDto == null)
                return BadRequest();

            await _notificationService.RemoveAsync(notificationDto);

            return Ok();
        }
    }
}
