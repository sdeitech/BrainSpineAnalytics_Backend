using BrainSpineAnalytics.Application.Dtos.Requests.Users;

namespace BrainSpineAnalytics.Application.Interfaces.Services.Users
{
 public interface IUserService
 {
 UserDto GetUserByUsername(string username);
 }
}
