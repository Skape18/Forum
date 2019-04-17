using AutoMapper;
using BLL.DTO.DTOs;
using Forum.ViewModels.TopicViewModels;

namespace Forum.AutomapperProfiles
{
    public class AutomapperTopicDtoProfile : Profile
    {
        public AutomapperTopicDtoProfile()
        {
            CreateMap<TopicDto, TopicViewModel>()
                .ForMember(dest => dest.NumberOfThreads, opt => opt.MapFrom(tdto => tdto.Threads.Count))
                .ReverseMap();

            CreateMap<CreateTopicViewModel, TopicDto>();
        }
    }
}
