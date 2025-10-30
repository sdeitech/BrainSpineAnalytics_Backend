using BrainSpineAnalytics.Application.DTOs.RequestDTOs.UserDTO;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Users;
using BrainSpineAnalytics.Application.Interfaces.Services.Users;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Services.Users
{
 public class UserService : IUserService
 {
 private readonly IUserRepo _repo;
 public UserService(IUserRepo repo)
 {
 _repo = repo;
 }

 public UserDTO GetUserByUsername(string username) => _repo.GetUserByUsername(username);
 }

}

