using System;
using System.Collections.Generic;
using Forum.ViewModels.PostViewModels;

namespace Forum.ViewModels.ThreadViewModel
{
    public class ThreadDisplayViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsOpen { get; set; }
        public DateTime ThreadOpenedDate { get; set; }
        public AuthorViewModel UserProfile { get; set; }
    }
}
