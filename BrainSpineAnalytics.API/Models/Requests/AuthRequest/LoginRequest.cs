using System.ComponentModel.DataAnnotations;

namespace BrainSpineAnalytics.API.Models.Requests.AuthRequest
{
    public class LoginRequest
    {
        [Required, EmailAddress, MaxLength(250)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
