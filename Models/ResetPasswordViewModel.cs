using System.ComponentModel.DataAnnotations;

namespace ConquerSite.Models
{
    public class ResetPasswordViewModel
    {

        public string Token { get; set; }
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmPassword { get; set; }
    }
}
