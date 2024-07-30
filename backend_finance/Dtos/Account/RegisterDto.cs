using System.ComponentModel.DataAnnotations;

namespace backend_finance.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string  Password { get; set; }
    }
}
