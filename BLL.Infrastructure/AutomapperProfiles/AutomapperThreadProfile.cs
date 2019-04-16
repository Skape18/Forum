using AutoMapper;
using BLL.DTO.DTOs;
using DAL.Domain.Entities;

namespace BLL.Infrastructure.AutomapperProfiles
{
    public class AutomapperThreadProfile : Profile
    {
        public AutomapperThreadProfile()
        {
            CreateMap<Thread, ThreadDto>()
                .ReverseMap();
        }
    }
}
