namespace BrainSpineAnalytics.Application.Interfaces.Repositories.Appointments
{
    using BrainSpineAnalytics.Application.DTOs.ResponseDTOs.Appointment;
    public interface IAppointmentRepo
    {
        List<AppointmentFactDTO> GetAppointments(int? clinicId);
    }
}
