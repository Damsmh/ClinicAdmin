using AutoMapper;
using ClinicAdmin.DTO;
using ClinicAdmin.Entities;
using ClinicAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAdmin.Services
{
    public class PrescriptionService(IPrescriptionRepository repository, IMapper mapper) : IPrescriptionService
    {
        public async Task<IEnumerable<PrescriptionResponse>> GetAllPrescriptionsAsync()
        {
            var prescriptions = await repository.GetAllAsync();
            var PrescriptionResponse = mapper.Map<IEnumerable<PrescriptionResponse>>(prescriptions);
            return PrescriptionResponse;
        }

        public async Task<PrescriptionResponse> GetPrescriptionByIdAsync([FromQuery] int id)
        {
            var prescription = await repository.GetByIdAsync(id);
            if (prescription == null)
                throw new KeyNotFoundException("Prescription not found");
            var PrescriptionResponse = mapper.Map<PrescriptionResponse>(prescription);

            return PrescriptionResponse;
        }

        public async Task<IEnumerable<PrescriptionResponse>> GetPrescriptionByDiagnosisIdAsync([FromQuery] int id)
        {
            var prescription = await repository.GetByDiagnosisIdAsync(id);
            if (prescription == null)
                throw new KeyNotFoundException("Prescription not found");
            var PrescriptionResponse = mapper.Map<IEnumerable<PrescriptionResponse>>(prescription);

            return PrescriptionResponse;
        }

        public async Task<IEnumerable<PrescriptionResponse>> GetPrescriptionByMedicationIdAsync([FromQuery] int id)
        {
            var prescription = await repository.GetByMedicationIdAsync(id);
            if (prescription == null)
                throw new KeyNotFoundException("Prescription not found");
            var PrescriptionResponse = mapper.Map<IEnumerable<PrescriptionResponse>>(prescription);

            return PrescriptionResponse;
        }
        public async Task AddPrescriptionAsync([FromBody] PrescriptionRequest prescriptionRequest)
        {
            var prescription = mapper.Map<Prescription>(prescriptionRequest);
            await repository.AddAsync(prescription);
        }


        public async Task UpdatePrescriptionAsync([FromQuery] int id, [FromBody] PrescriptionRequest prescriptionRequest)
        {
            var Prescription = await repository.GetByIdAsync(id);
            if (Prescription == null)
                throw new KeyNotFoundException("Prescription not found");
            Prescription = mapper.Map<Prescription>(prescriptionRequest);
            Prescription.PrescriptionId = id;
            await repository.UpdateAsync(Prescription);
        }


        public async Task DeletePrescriptionAsync([FromQuery] int id)
        {
            var Prescription = await repository.GetByIdAsync(id);
            if (Prescription == null)
                throw new KeyNotFoundException("Prescription not found");
            await repository.DeleteAsync(id);
        }
    }
}
