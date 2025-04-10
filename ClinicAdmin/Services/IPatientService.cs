using ClinicAdmin.DTO.Patient;
using ClinicAdmin.Repositories;

namespace ClinicAdmin.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientResponse>> GetAllPatientsAsync();
        Task<PatientResponse> GetPatientByIdAsync(Guid id);
        Task AddPatientAsync(PatientRequest patientRequest);
        Task UpdatePatientAsync(Guid id, PatientRequest patientRequest);
        Task DeletePatientAsync(Guid id);
    }
}
