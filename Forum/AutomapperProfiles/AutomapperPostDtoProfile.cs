﻿using System;
using AutoMapper;
using BLL.DTO.DTOs;
using Forum.ViewModels.PostViewModels;

namespace Forum.AutomapperProfiles
{
    public class AutomapperPostDtoProfile : Profile
    {
        public AutomapperPostDtoProfile()
        {
            CreateMap<PostDto, PostDisplayViewModel>();

            CreateMap<PostDto, RepliedPostViewModel>();

            CreateMap<CreatePostViewModel, PostDto>()
                .ForMember(dest => dest.PostDate, opt => opt.MapFrom(cpd => DateTime.Now));
        }
    }
}
