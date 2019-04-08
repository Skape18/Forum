using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO.DTOs
{
    public class RegistrationDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfileImagePath { get; set; }
    }
}
