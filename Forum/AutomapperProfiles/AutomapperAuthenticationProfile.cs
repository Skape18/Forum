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

            CreateMap<SignedInUserDto, SignedInUserViewModel>()
                .ForMember(dest=> dest.Id, opt => opt.MapFrom(siudto => siudto.User.Id ))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(siudto => siudto.User.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(siudto => siudto.User.Email))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(siudto => siudto.User.IsActive))
                .ForMember(dest => dest.ProfileImagePath, opt => opt.MapFrom(siudto => siudto.User.ProfileImagePath))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(siudto => siudto.User.Rating))
                .ForMember(dest => dest.ProfileImagePath, opt => opt.MapFrom(siudto => siudto.User.ProfileImagePath));
        }
    }
}
