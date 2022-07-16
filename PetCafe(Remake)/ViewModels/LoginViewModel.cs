using System.ComponentModel.DataAnnotations;

namespace PetCafe_Remake_.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email Address")]
        [EmailAddress]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}