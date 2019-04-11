using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.ViewModels.AccountViewModels
{
    public class SignedInUserViewModel
    {
        public UserViewModel User { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
    }
}
