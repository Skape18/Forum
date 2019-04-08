

using AutoMapper;
using BLL.DTO.DTOs;
using Forum.ViewModels;

namespace Forum.AutomapperProfiles
{
    public class AutomapperUserDtoProfile : Profile
    {
        public AutomapperUserDtoProfile()
        {
            CreateMap<UserDto, PostAuthorViewModel>();
        }
    }
}
