using AutoMapper;
using BLL.DTO.DTOs;
using DAL.Domain.Entities;

namespace BLL.Infrastructure.AutomapperProfiles
{
    public class AutomapperNotificationProfile : Profile
    {
        public AutomapperNotificationProfile()
        {
            CreateMap<Notification, NotificationDto>().ReverseMap(); 
        }
    }
}
