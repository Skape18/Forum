using System;

namespace Forum.ViewModels.PostViewModels
{
    public class PostDisplayViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public AuthorViewModel UserProfile { get; set; }
        public RepliedPostViewModel RepliedPost { get; set; }
    }
}
