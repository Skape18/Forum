using AutoMapper;
using BLL.DTO.DTOs;
using DAL.Domain.Entities;

namespace BLL.Infrastructure.AutomapperProfiles
{
    class AutomapperApplicationUserProfile : Profile
    {
        public AutomapperApplicationUserProfile()
        {
            CreateMap<RegistrationDto, ApplicationUser>();
        }
    }
}
