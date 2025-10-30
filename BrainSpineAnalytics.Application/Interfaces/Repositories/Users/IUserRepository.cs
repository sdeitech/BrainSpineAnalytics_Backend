using BrainSpineAnalytics.Application.Dtos.Requests.Users;

namespace BrainSpineAnalytics.Application.Interfaces.Repositories.Users
{
 public interface IUserRepository
 {
 UserDto GetUserByUsername(string username);
 }
}
