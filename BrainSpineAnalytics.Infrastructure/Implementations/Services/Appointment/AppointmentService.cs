using BrainSpineAnalytics.Application.Interfaces.Repositories.Appointment;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Users;
using BrainSpineAnalytics.Application.Interfaces.Services.Appointment;
using BrainSpineAnalytics.Domain.Entities;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Services.Appointment
{
 public class AppointmentService : IAppointmentService
 {
 private readonly IUserRepo _userRepo;
 private readonly IAppointmentRepo _apptRepo;

 public AppointmentService(IUserRepo userRepo, IAppointmentRepo apptRepo)
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

