using BrainSpineAnalytics.Application.Dtos.Requests.Users;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Users;
using BrainSpineAnalytics.Infrastructure.Data;
using System.Linq;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly BrainSpineDbContext _context;
        public UserRepository(BrainSpineDbContext context)
        {
            _context = context;
        }
        public UserDto GetUserByUsername(string username)
        {
            var user = (from u in _context.DummyDimUsers
                        where u.Username == username
                        select new UserDto
                        {
                            UserId = u.Id,
                            Username = u.Username,
                            FullName = u.FullName,
                            ClinicId = u.ClinicId
                        }).FirstOrDefault();
            return user;
        }
    }
}
