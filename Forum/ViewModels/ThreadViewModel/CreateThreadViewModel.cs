using System;

namespace Forum.ViewModels.ThreadViewModel
{
    public class CreateThreadViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsOpen { get; set; }
        public DateTime ThreadOpenedDate { get; set; }
        public int UserProfileId { get; set; }
        public int TopicId { get; set; }
    }
}
