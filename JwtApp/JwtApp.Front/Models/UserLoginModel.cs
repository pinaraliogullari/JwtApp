using System.ComponentModel.DataAnnotations;

namespace JwtApp.Front.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Username alanı gereklidir.")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Username alanı gereklidir.")]
        public string Password { get; set; } = null!;
    }
}
