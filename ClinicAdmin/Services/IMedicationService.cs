using ClinicAdmin.DTO;

namespace ClinicAdmin.Services
{
    public interface IMedicationService
    {
        Task<IEnumerable<MedicationResponse>> GetAllMedicationsAsync();
        Task<MedicationResponse> GetMedicationByIdAsync(int id);
        Task AddMedicationAsync(MedicationRequest medicationRequest);
        Task UpdateMedicationAsync(int id, MedicationRequest medicationRequest);
        Task DeleteMedicationAsync(int id);
    }
}
