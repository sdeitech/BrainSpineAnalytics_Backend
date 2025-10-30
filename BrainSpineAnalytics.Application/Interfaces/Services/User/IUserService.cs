using BrainSpineAnalytics.Application.DTOs.RequestDTOs.UserDTO;

namespace BrainSpineAnalytics.Application.Interfaces.Services.Users
{
 public interface IUserService
 {
 UserDTO GetUserByUsername(string username);
 }
}

