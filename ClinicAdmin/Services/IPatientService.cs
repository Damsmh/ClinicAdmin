using ClinicAdmin.DTO;
using ClinicAdmin.Repositories;

namespace ClinicAdmin.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientResponse>> GetAllPatientsAsync();
        Task<PatientResponse> GetPatientByIdAsync(int id);
        Task AddPatientAsync(PatientRequest patientRequest);
        Task UpdatePatientAsync(int id, PatientRequest patientRequest);
        Task DeletePatientAsync(int id);
    }
}
