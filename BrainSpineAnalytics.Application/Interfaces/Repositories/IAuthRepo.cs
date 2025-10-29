using BrainSpineAnalytics.Domain.Entities;

namespace BrainSpineAnalytics.Application.Interfaces.Repositories
{
    public interface IAuthRepo
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task<IReadOnlyList<string>> GetActiveRoleNamesByUserIdAsync(int userId);
        Task UpdatePasswordHashAsync(int userId, string newPasswordHash);
        Task AddUserRoleMappingAsync(int userId, int roleId);
    }
}
