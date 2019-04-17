using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.DTOs;
using Forum.ViewModels;
using Forum.ViewModels.ThreadViewModel;

namespace Forum.AutomapperProfiles
{
    public class AutomapperThreadDtoProfile : Profile
    {
        public AutomapperThreadDtoProfile()
        {
            CreateMap<ThreadDto, ThreadDisplayViewModel>()
                .ForMember(dest => dest.PostsNumber, opt => opt.MapFrom(tdto => tdto.Posts.Count))
                .ReverseMap();

            CreateMap<CreateThreadViewModel, ThreadDto>()
                .ForMember(dest => dest.ThreadOpenedDate, opt => opt.MapFrom(ctvm => DateTime.Now))
                .ForMember(dest => dest.IsOpen, opt => opt.MapFrom(ctvm => true));
        }
    }
}
