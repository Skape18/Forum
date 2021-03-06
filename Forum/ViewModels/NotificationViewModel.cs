﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.ViewModels
{
    public class NotificationViewModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserProfileId { get; set; }
        public string ThreadTitle { get; set; }
        public DateTime NotificationDate { get; set; }
    }
}
