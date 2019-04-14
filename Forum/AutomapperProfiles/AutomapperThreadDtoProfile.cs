﻿using System;
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
                .ReverseMap();

            CreateMap<CreateThreadViewModel, CreateThreadViewModel>()
                .ForMember(dest => dest.ThreadOpenedDate, opt => opt.MapFrom(ctvm => DateTime.Now));
        }
    }
}