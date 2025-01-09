using System.ComponentModel.DataAnnotations;

namespace ASPMVC_Demo01.Models
{
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
