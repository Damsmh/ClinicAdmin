using ClinicAdmin.Entities;

namespace ClinicAdmin.Repositories
{
    public interface IDiagnosisRepository
    {
        Task<IEnumerable<Diagnosis>> GetAllAsync();
        Task<Diagnosis> GetByIdAsync(int id);
        Task<IEnumerable<Diagnosis>> GetByAppointmentIdAsync(int appointmentId);
        Task AddAsync(Diagnosis Diagnosis);
        Task UpdateAsync(Diagnosis Diagnosis);
        Task DeleteAsync(int id);
    }
}
