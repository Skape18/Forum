using System;
using DAL.Domain.Base;

namespace DAL.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public DateTime NotificationDate { get; set; }
    }
}
