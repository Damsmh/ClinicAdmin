using ClinicAdmin.Entities;

namespace ClinicAdmin.Repositories
{
    public interface IMedicationRepository
    {
        Task<IEnumerable<Medication>> GetAllAsync();
        Task<Medication> GetByIdAsync(int id);
        Task AddAsync(Medication medication);
        Task UpdateAsync(Medication medication);
        Task DeleteAsync(int id);
    }
}
