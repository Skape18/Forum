using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO.DTOs;

namespace BLL.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDto>> GetAllAsync();
        Task<NotificationDto> GetByIdAsync(int id);
        Task CreateAsync(NotificationDto notificationDto); 
        Task RemoveAsync(NotificationDto notificationDto);
    }
}