using AutoMapper;
using BLL.DTO.DTOs;
using DAL.Domain.Entities;

namespace BLL.Infrastructure.AutomapperProfiles
{
    public class AutomapperTopicProfile : Profile
    {
        public AutomapperTopicProfile()
        {
            CreateMap<Topic, TopicDto>().ReverseMap();
        }
    }
}
