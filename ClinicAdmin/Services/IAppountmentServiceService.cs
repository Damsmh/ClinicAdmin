using ClinicAdmin.DTO;

namespace ClinicAdmin.Services
{
    public interface IAppointmentServiceService
    {
        Task<IEnumerable<AppointmentServiceResponse>> GetAllAppointmentServicesAsync();
        Task<AppointmentServiceResponse> GetAppointmentServiceByIdAsync(int id);
        Task<IEnumerable<AppointmentServiceResponse>> GetAppointmentServiceByAppointmentIdAsync(int id);
        Task<IEnumerable<AppointmentServiceResponse>> GetAppointmentServiceByServiceIdAsync(int id);
        Task AddAppointmentServiceAsync(AppointmentServiceRequest appointmentRequest);
        Task UpdateAppointmentServiceAsync(int id, AppointmentServiceRequest appointmentRequest);
        Task DeleteAppointmentServiceAsync(int id);
    }
}
