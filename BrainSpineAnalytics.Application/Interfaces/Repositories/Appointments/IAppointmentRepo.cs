namespace BrainSpineAnalytics.Application.Interfaces.Repositories.Appointments
{
 using BrainSpineAnalytics.Domain.Entities;
 public interface IAppointmentRepo
 {
 List<AppointmentFact> GetAppointments(int? clinicId);
 }
}
