using System.Threading;
using AutoMapper;
using BLL.DTO.DTOs;

namespace BLL.Infrastructure.AutomapperProfiles
{
    public class AutomapperThreadProfile : Profile
    {
        public AutomapperThreadProfile()
        {
            CreateMap<Thread, ThreadDto>().ReverseMap();
        }
    }
}
