using AutoMapper;
using BLL.DTO.DTOs;
using BLL.Interfaces;
using Forum.ViewModels.AccountViewModels;

namespace Forum.AutomapperProfiles
{
    public class AutomapperAuthenticationProfile : Profile
    {
        public AutomapperAuthenticationProfile()
        {
            CreateMap<LoginViewModel, LoginDto>();
            CreateMap<RegistrationViewModel, RegistrationDto>();
            CreateMap<SignedInUserDto, SignedInUserViewModel>();
        }
    }
}
