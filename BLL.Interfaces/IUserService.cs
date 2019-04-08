using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO.DTOs;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsUserInRole(int userId, string role);

        Task<bool> IsUserInRole(string userName, string role);

        Task<ICollection<string>> GetRoles(int userId);

        Task<string> SignIn(LoginDto loginDto, string tokenKey, int tokenLifetime, string tokenAudience, string tokenIssuer);

        Task SignOut(int userId);

        Task<string> SignUp(RegistrationDto registrationDto, string tokenKey, int tokenLifetime,string tokenAudience, string tokenIssuer);
    
    }
}