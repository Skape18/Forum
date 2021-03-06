﻿using System.Collections.Generic;
using DAL.Domain.Base;

namespace DAL.Domain.Entities
{
    public class Topic : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public ICollection<Thread> Threads { get; set; } = new List<Thread>();
    }
}
