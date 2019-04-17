using System;

namespace Forum.ViewModels.AccountViewModels
{
    public class SignedInUserViewModel
    {
        public int Id { get; set; }
        public string ProfileImagePath { get; set; }
        public int Rating { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
