using BrainSpineAnalytics.Application.Interfaces.Repositories.Revenue;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Users;
using BrainSpineAnalytics.Application.Interfaces.Services.Revenue;
using BrainSpineAnalytics.Application.Dtos.Requests.Revenue;
using System;
using System.Collections.Generic;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Services.Revenue
{
    public class RevenueService : IRevenueService
    {
        private readonly IUserRepository _userRepo;
        private readonly IRevenueRepo _revRepo;

        public RevenueService(IUserRepository userRepo, IRevenueRepo revRepo)
        {
            _userRepo = userRepo;
            _revRepo = revRepo;
        }
        
        public List<RevenueFactDto> GetRevenueByUser(string username)
        {
            var user = _userRepo.GetUserByUsername(username);
            if (user == null) throw new Exception("User not found");
            return _revRepo.GetRevenue(user.ClinicId);
        }
    }
}
