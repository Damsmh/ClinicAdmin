using AutoMapper;
using ClinicAdmin.DTO;
using ClinicAdmin.Entities;
using ClinicAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAdmin.Services
{
    public class MedicationService(IMedicationRepository repository, IMapper mapper) : IMedicationService
    {
        public async Task<IEnumerable<MedicationResponse>> GetAllMedicationsAsync()
        {
            var Medications = await repository.GetAllAsync();
            var MedicationResponse = mapper.Map<IEnumerable<MedicationResponse>>(Medications);
            return MedicationResponse;
        }

        public async Task<MedicationResponse> GetMedicationByIdAsync([FromQuery] int id)
        {
            var Medication = await repository.GetByIdAsync(id);
            if (Medication == null)
                throw new KeyNotFoundException("Medication not found");
            var MedicationResponse = mapper.Map<MedicationResponse>(Medication);

            return MedicationResponse;
        }
        public async Task AddMedicationAsync([FromBody] MedicationRequest MedicationRequest)
        {
            var Medication = mapper.Map<Medication>(MedicationRequest);
            await repository.AddAsync(Medication);
        }


        public async Task UpdateMedicationAsync([FromQuery] int id, [FromBody] MedicationRequest MedicationRequest)
        {
            var Medication = await repository.GetByIdAsync(id);
            if (Medication == null)
                throw new KeyNotFoundException("Medication not found");

            Medication = mapper.Map<Medication>(MedicationRequest);
            Medication.MedicationId = id;
            await repository.UpdateAsync(Medication);
        }


        public async Task DeleteMedicationAsync([FromQuery] int id)
        {
            var Medication = await repository.GetByIdAsync(id);


            if (Medication == null)
                throw new KeyNotFoundException("Medication not found");


            await repository.DeleteAsync(id);
        }
    }
}
