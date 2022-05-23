using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels.AccountViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string ProfileImagePath { get; set; }
    }
}
