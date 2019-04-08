using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.DTOs;
using BLL.Interfaces;
using DAL.Domain.Entities;
using DAL.Interfaces;

namespace BLL.Infrastructure.Services
{
    public class NotificationService : BaseService, INotificationService
    {

        public NotificationService(IUnitOfWork unitOfWork, IMapper mapper):base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<NotificationDto>> GetAllAsync()
        {
            var notifications = await UnitOfWork.Notifications.GetAllAsync();

            return Mapper.Map<IEnumerable<Notification>, List<NotificationDto>>(notifications);
        }

        public async Task<IEnumerable<NotificationDto>> GetAllSortedByDate()
        {
            var notifications = await UnitOfWork.Notifications.GetWithPredicatesAsync(n => n.NotificationDate);

            return Mapper.Map<IEnumerable<Notification>, List<NotificationDto>>(notifications);
        }

        public async Task<NotificationDto> GetByIdAsync(int id)
        {
            var notification = await UnitOfWork.Notifications.GetByIdAsync(id);

            if (notification != null)
                return Mapper.Map<Notification, NotificationDto>(notification);

            return null;
        }

        public async Task CreateAsync(NotificationDto notificationDto)
        {
            if (notificationDto == null)
                return;
            
            var notification = Mapper.Map<NotificationDto, Notification>(notificationDto);

            await UnitOfWork.Notifications.CreateAsync(notification);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(NotificationDto notificationDto)
        {
            if (notificationDto == null)
                return;

            var notification = Mapper.Map<NotificationDto, Notification>(notificationDto);

            UnitOfWork.Notifications.Remove(notification);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
