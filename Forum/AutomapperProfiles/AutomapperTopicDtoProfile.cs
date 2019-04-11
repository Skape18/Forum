using AutoMapper;
using BLL.DTO.DTOs;
using Forum.ViewModels;

namespace Forum.AutomapperProfiles
{
    public class AutomapperTopicDtoProfile : Profile
    {
        public AutomapperTopicDtoProfile()
        {
            CreateMap<TopicDto, TopicViewModel>()
                .ReverseMap();
        }
    }
}
