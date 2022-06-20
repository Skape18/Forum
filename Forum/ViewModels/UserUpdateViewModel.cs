using System.Collections.Generic;

namespace Forum.ViewModels
{
    public class UserUpdateViewModel
    {
        public IEnumerable<int> TagIds { get; set; }

        public string Description { get; set; }
    }
}