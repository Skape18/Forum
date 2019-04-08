using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.ViewModels
{
    public class PostAuthorViewModel
    {
        public int Id { get; set; }
        public string ProfileImagePath { get; set; }
        public int Rating { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
