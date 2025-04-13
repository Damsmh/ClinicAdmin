using ClinicAdmin.DTO;
namespace ClinicAdmin.Services
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<PrescriptionResponse>> GetAllPrescriptionsAsync();
        Task<PrescriptionResponse> GetPrescriptionByIdAsync(int id);
        Task<IEnumerable<PrescriptionResponse>> GetPrescriptionByDiagnosisIdAsync(int id);
        Task<IEnumerable<PrescriptionResponse>> GetPrescriptionByMedicationIdAsync(int id);
        Task AddPrescriptionAsync(PrescriptionRequest prescriptionRequest);
        Task UpdatePrescriptionAsync(int id, PrescriptionRequest prescriptionRequest);
        Task DeletePrescriptionAsync(int id);
    }
}
