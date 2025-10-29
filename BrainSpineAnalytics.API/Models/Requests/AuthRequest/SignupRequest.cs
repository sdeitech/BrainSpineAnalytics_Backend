using System.ComponentModel.DataAnnotations;

namespace BrainSpineAnalytics.API.Models.Requests.AuthRequest
{
    public class SignupRequest
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        [Required, EmailAddress, MaxLength(250)]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(8)]
        public string Password { get; set; } = string.Empty;
    }
}
