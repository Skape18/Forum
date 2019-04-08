using System;
using System.Collections.Generic;
using BLL.DTO.DTOs;

namespace Forum.ViewModels.PostViewModels
{
    public class CreatePostViewModel
    {
        public string Content { get; set; }
        public int UserProfileId { get; set; }
        public int ThreadId { get; set; }
        public int? RepliedPostId { get; set; }
    }
}
