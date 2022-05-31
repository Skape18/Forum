using AutoMapper;
using BLL.DTO.DTOs;
using DAL.Domain.Entities;

namespace BLL.Infrastructure.AutomapperProfiles
{
    public class AutomapperUserProfile : Profile
    {
        public AutomapperUserProfile()
        {
            CreateMap<UserProfile, UserDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(up => up.ApplicationUser.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(up => up.ApplicationUser.Email))
                .ReverseMap()
                .ForMember(dest => dest.Posts, opt => opt.Ignore())
                .ForMember(dest => dest.Threads, opt => opt.Ignore())
                //.ForMember(dest => dest.Notifications, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.Ignore());
        }
    }
}
