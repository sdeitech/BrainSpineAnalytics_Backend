using BrainSpineAnalytics.Application.DTOs.RequestDTOs.UserDTO;

namespace BrainSpineAnalytics.Application.Interfaces.Repositories.Users
{
 public interface IUserRepo
 {
 UserDTO GetUserByUsername(string username);
 }
}

