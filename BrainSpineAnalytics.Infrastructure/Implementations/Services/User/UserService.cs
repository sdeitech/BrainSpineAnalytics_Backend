using BrainSpineAnalytics.Application.Dtos.Requests.Users;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Users;
using BrainSpineAnalytics.Application.Interfaces.Services.Users;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Services.Users
{
 public class UserService : IUserService
 {
 private readonly IUserRepository _repo;
 public UserService(IUserRepository repo)
 {
 _repo = repo;
 }

 public UserDto GetUserByUsername(string username) => _repo.GetUserByUsername(username);
 }

}


