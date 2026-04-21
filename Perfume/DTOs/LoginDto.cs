using System.ComponentModel.DataAnnotations;

namespace Perfume.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Mail alanı zorunludur.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        public string Password { get; set; }
    }
}
