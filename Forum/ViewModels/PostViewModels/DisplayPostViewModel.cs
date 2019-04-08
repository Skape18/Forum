using System;

namespace Forum.ViewModels.PostViewModels
{
    public class DisplayPostViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public PostAuthorViewModel UserProfile { get; set; }
    }
}
