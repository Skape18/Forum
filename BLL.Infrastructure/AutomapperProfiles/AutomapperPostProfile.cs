using AutoMapper;
using BLL.DTO.DTOs;
using DAL.Domain.Entities;

namespace BLL.Infrastructure.AutomapperProfiles
{
    public class AutomapperPostProfile : Profile
    {
        public AutomapperPostProfile()
        {
            CreateMap<Post, PostDto>()
                .ReverseMap()
                .ForMember(dest => dest.UserProfile, opt => opt.Ignore())
                .ForMember(dest => dest.Thread, opt => opt.Ignore())
                .ForMember(dest => dest.RepliedPost, opt => opt.Ignore());
        }
    }
}
