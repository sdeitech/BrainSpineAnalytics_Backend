using BrainSpineAnalytics.Application.Interfaces.Repositories;
using BrainSpineAnalytics.Domain.Entities;
using BrainSpineAnalytics.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Repositories
{
    public class AuthRepo : IAuthRepo
    {
        private readonly BrainSpineDBContext _context;
        public AuthRepo(BrainSpineDBContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.IsActive && !u.IsDeleted);
        }

        public async Task<IReadOnlyList<string>> GetActiveRoleNamesByUserIdAsync(int userId)
        {
            return await (from urm in _context.UserRoleMappings
                          join r in _context.Roles on urm.RoleId equals r.RoleId
                          where urm.UserId == userId && urm.IsActive && !urm.IsDeleted && r.IsActive && !r.IsDeleted
                          select r.Name).ToListAsync();
        }

        public async Task UpdatePasswordHashAsync(int userId, string newPasswordHash)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user is null) return;
            user.PasswordHash = newPasswordHash;
            await _context.SaveChangesAsync();
        }

        // Create a user-role mapping
        public async Task AddUserRoleMappingAsync(int userId, int roleId)
        {
            var mapping = new UserRoleMapping
            {
                UserId = userId,
                RoleId = roleId,
                IsActive = true,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow
            };
            await _context.UserRoleMappings.AddAsync(mapping);
            await _context.SaveChangesAsync();
        }
    }
}
