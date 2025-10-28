using BrainSpineAnalytics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Application.Interfaces.Repositories
{
    public interface IAuthRepo
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
