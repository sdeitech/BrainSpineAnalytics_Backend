namespace BrainSpineAnalytics.Application.Interfaces.Services.Appointments
{
    using BrainSpineAnalytics.Application.DTOs.ResponseDTOs.Appointment;
    using BrainSpineAnalytics.Domain.Entities;
    public interface IAppointmentService
    {
        List<AppointmentFactDTO> GetAppointmentsByUser(string username);
    }
}
