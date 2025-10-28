using BrainSpineAnalytics.Application.Interfaces.Repositories;
using BrainSpineAnalytics.Domain.Entities;
using BrainSpineAnalytics.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Repositories
{
    public class AutRepo : IAuthRepo
    {
        private readonly BrainSpineDBContext _context;
        public AutRepo(BrainSpineDBContext context)
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
    }
}
