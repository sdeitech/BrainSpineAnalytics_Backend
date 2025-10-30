using BrainSpineAnalytics.Application.Interfaces.Repositories.Appointments;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Users;
using BrainSpineAnalytics.Application.Interfaces.Services.Appointments;
using BrainSpineAnalytics.Domain.Entities;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Services.Appointment
{
 public class AppointmentService : IAppointmentService
 {
 private readonly IUserRepository _userRepo;
 private readonly IAppointmentRepo _apptRepo;

 public AppointmentService(IUserRepository userRepo, IAppointmentRepo apptRepo)
 {
 _userRepo = userRepo;
 _apptRepo = apptRepo;
 }

 public List<AppointmentFact> GetAppointmentsByUser(string username)
 {
 var user = _userRepo.GetUserByUsername(username);
 if (user == null) throw new Exception("User not found");
 return _apptRepo.GetAppointments(user.ClinicId);
 }
 }
}


