using System;


namespace BLL.DTO.DTOs
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public PostDto Post { get; set; }
        public int UserProfileId { get; set; }
        public UserDto UserProfile { get; set; }
        public DateTime NotificationDate { get; set; }
    }
}
