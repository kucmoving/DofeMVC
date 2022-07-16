using System.ComponentModel.DataAnnotations;

namespace PetCafe_Remake_.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
