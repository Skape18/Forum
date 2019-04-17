using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels.ThreadViewModel
{
    public class CreateThreadViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int UserProfileId { get; set; }

        [Required]
        public int TopicId { get; set; }
    }
}
