using ClinicAdmin.DTO;

namespace ClinicAdmin.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceResponse>> GetAllServicesAsync();
        Task<ServiceResponse> GetServiceByIdAsync(int id);
        Task AddServiceAsync(ServiceRequest serviceRequest);
        Task UpdateServiceAsync(int id, ServiceRequest serviceRequest);
        Task DeleteServiceAsync(int id);
    }
}
