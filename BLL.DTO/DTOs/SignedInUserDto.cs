using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO.DTOs
{
    public class SignedInUserDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }


        public SignedInUserDto(UserDto user, string token, bool isAdmin)
        {
            User = user;
            Token = token;
            IsAdmin = isAdmin;
        }
    }
}
