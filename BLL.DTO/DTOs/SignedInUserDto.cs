using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO.DTOs
{
    public class SignedInUserDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
        public SignedInUserDto(UserDto user, string token)
        {
            User = user;
            Token = token;
        }
    }
}
