using ClinicAdmin.DTO;

namespace ClinicAdmin.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentResponse>> GetAllAppointmentsAsync();
        Task<AppointmentResponse> GetAppointmentByIdAsync(int id);
        Task<IEnumerable<AppointmentResponse>> GetAppointmentByPatientIdAsync(int id);
        Task<IEnumerable<AppointmentResponse>> GetAppointmentByEmployeeIdAsync(int id);
        Task AddAppointmentAsync(AppointmentRequest appointmentRequest);
        Task UpdateAppointmentAsync(int id, AppointmentRequest appointmentRequest);
        Task DeleteAppointmentAsync(int id);
    }
}
