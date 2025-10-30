namespace BrainSpineAnalytics.Application.Dtos.Requests.Users
{
 public class UserDto
 {
 public int UserId { get; set; }
 public string Username { get; set; } = string.Empty;
 public string? FullName { get; set; }
 public string Email { get; set; } = string.Empty;
 public int? ClinicId { get; set; }
 }
}
