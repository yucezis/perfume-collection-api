using System.ComponentModel.DataAnnotations;

namespace Perfume.DTOs
{
    public class RegisterDto
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim alanı zorunludur.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Mail alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Password { get; set; }
    }
}
