using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Forum.ViewModels.TopicViewModels
{
    public class CreateTopicViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        
        public IFormFile Image { get; set; }
    }
}
