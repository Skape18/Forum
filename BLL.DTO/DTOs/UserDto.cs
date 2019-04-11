using System;
using System.Collections.Generic;

namespace BLL.DTO.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string ProfileImagePath { get; set; }
        public int Rating { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public ICollection<PostDto> Posts { get; set; }
        public ICollection<ThreadDto> Threads { get; set; }
        public ICollection<NotificationDto> Notifications { get; set; }
    }
}
