using System;
using System.Collections.Generic;
using DAL.Domain.Entities;

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
        public string Description { get; set; }

        public ICollection<PostDto> Posts { get; set; }
        public ICollection<ThreadDto> Threads { get; set; }
        public ICollection<NotificationDto> Notifications { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
