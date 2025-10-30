namespace BrainSpineAnalytics.Application.Interfaces.Services.Appointments
{
 using BrainSpineAnalytics.Domain.Entities;
 public interface IAppointmentService
 {
 List<AppointmentFact> GetAppointmentsByUser(string username);
 }
}
