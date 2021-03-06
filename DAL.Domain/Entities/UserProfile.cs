﻿using System;
using System.Collections.Generic;
using DAL.Domain.Base;

namespace DAL.Domain.Entities
{
    public class UserProfile : BaseEntity
    {
        public string ProfileImagePath { get; set; }
        public int Rating { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegistrationDate { get; set; }

        public string ApplicationUserId  { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Thread> Threads { get; set; } = new List<Thread>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
