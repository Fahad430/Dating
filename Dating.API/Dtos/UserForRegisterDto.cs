using System.ComponentModel.DataAnnotations;

namespace Dating.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
      // [StringLength(4, ErrorMessage = "You must specify password between 4 and 8")]
        public string Password { get; set; }
    }
}