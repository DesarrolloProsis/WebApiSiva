using System.ComponentModel.DataAnnotations;

namespace WebApiSiva.Dtos
{
    public class UserForLoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 16 characters.")]
        public string Password { get; set; }
    }
}