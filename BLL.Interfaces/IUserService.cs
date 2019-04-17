using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO.DTOs;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsUserInRoleAsync(string userName, string role);

        Task<ICollection<string>> GetRolesAsync(int userId);

        Task<SignedInUserDto> SignInAsync(LoginDto loginDto, string tokenKey, int tokenLifetime, string tokenAudience, string tokenIssuer);

        Task SignOutAsync();

        Task<SignedInUserDto> SignUpAsync(RegistrationDto registrationDto, string tokenKey, int tokenLifetime,string tokenAudience, string tokenIssuer);

        Task<UserDto> GetUserDetailsAsync(int userId);

        Task<bool> Deactivate(int userId);

        Task UpdateImage(int userId, string profileImageName, string rootPath, byte[] image);
    }
}