namespace BrainSpineAnalytics.Application.Dtos.Responses.Auth
{
 public class AuthResponse
 {
 public bool Success { get; set; }
 public string Message { get; set; } = string.Empty;
 public string? Token { get; set; }
 }
}
