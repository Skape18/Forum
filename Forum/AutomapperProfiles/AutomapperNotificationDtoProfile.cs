using System;
using AutoMapper;
using BLL.DTO.DTOs;
using Forum.ViewModels;

namespace Forum.AutomapperProfiles
{
    public class AutomapperNotificationDtoProfile : Profile
    {
        public AutomapperNotificationDtoProfile()
        {
            CreateMap<NotificationDto, NotificationViewModel>()
                .ForMember(nvm => nvm.ThreadTitle, opt => opt.MapFrom(ndto => ndto.Post.Thread.Title))
                .ReverseMap()
                .ForMember(ndto => ndto.NotificationDate, opt => opt.MapFrom(nvm => DateTime.Now));
        }
    }
}
