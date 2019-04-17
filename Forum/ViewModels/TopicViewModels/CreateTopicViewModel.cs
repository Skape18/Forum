using Microsoft.AspNetCore.Http;

namespace Forum.ViewModels.TopicViewModels
{
    public class CreateTopicViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
