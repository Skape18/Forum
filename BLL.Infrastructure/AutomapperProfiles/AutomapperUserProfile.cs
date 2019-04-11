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
                .ReverseMap();
        }
    }
}
