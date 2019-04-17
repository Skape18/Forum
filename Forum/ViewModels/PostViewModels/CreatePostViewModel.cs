using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels.PostViewModels
{
    public class CreatePostViewModel
    {
        [Required]
        public string Content { get; set; }
        
        [Required]
        public int UserProfileId { get; set; }

        [Required]
        public int ThreadId { get; set; }

        public int? RepliedPostId { get; set; }
    }
}
