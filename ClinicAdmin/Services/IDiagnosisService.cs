using ClinicAdmin.DTO;

namespace ClinicAdmin.Services
{
    public interface IDiagnosisService
    {
        Task<IEnumerable<DiagnosisResponse>> GetAllDiagnosesAsync();
        Task<DiagnosisResponse> GetDiagnosisByIdAsync(int id);
        Task<IEnumerable<DiagnosisResponse>> GetDiagnosesByAppointmentIdAsync(int id);
        Task AddDiagnosisAsync(DiagnosisRequest diagnosisRequest);
        Task UpdateDiagnosisAsync(int id, DiagnosisRequest diagnosisRequest);
        Task DeleteDiagnosisAsync(int id);
    }
}
