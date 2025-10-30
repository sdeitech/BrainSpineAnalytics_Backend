using BrainSpineAnalytics.Application.DTOs.RequestDTOs.UserDTO;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Users;
using BrainSpineAnalytics.Infrastructure.Data;
using System.Linq;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Users
{
    public class UserRepo : IUserRepo
    {
        private readonly BrainSpineDBContext _context;
        public UserRepo(BrainSpineDBContext context)
        {
            _context = context;
        }
        public UserDTO GetUserByUsername(string username)
        {
            //var data = _context.DummyDimUsers.Where(x => x.Username == username).FirstOrDefault();
                       // where u.Username == username
            var user = (from u in _context.DummyDimUsers
                        where u.Username == username
                        select new UserDTO
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
