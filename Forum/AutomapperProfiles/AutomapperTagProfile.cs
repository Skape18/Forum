using AutoMapper;
using DAL.Domain.Entities;
using Forum.ViewModels;

namespace Forum.AutomapperProfiles
{
    public class AutomapperTagProfile : Profile
    {
        public AutomapperTagProfile()
        {
            CreateMap<Tag, TagViewModel>();
        }
    }
}