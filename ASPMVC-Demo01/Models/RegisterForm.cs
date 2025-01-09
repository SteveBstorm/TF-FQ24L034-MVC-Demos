using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPMVC_Demo01.Models
{
    public class RegisterForm
    {
        [Required]
        [EmailAddress]
        [DisplayName("Adresse email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Nom d'utilisateur")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
