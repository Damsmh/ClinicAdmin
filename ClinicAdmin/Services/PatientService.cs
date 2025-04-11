using AutoMapper;
using ClinicAdmin.DTO;
using ClinicAdmin.Entities;
using ClinicAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAdmin.Services
{
    public class PatientService(IPatientRepository repository, IMapper mapper) : IPatientService
    {
        public async Task<IEnumerable<PatientResponse>> GetAllPatientsAsync()
        {
            var patients = await repository.GetAllAsync();
            var PatientResponse = mapper.Map<IEnumerable<PatientResponse>>(patients);
            return PatientResponse;
        }

        public async Task<PatientResponse> GetPatientByIdAsync([FromQuery] int id)
        {
            var patient = await repository.GetByIdAsync(id);
            if (patient == null)
                throw new KeyNotFoundException("Patient not found");
            var PatientResponse = mapper.Map<PatientResponse>(patient);

            return PatientResponse;
        }
        public async Task AddPatientAsync([FromBody] PatientRequest patientRequest)
        {

            var patient = mapper.Map<Patient>(patientRequest);

            await repository.AddAsync(patient);
        }


        public async Task UpdatePatientAsync([FromQuery] int id, [FromBody] PatientRequest patientRequest)
        {
            var Patient = await repository.GetByIdAsync(id);
            if (Patient == null)
                throw new KeyNotFoundException("Patient not found");
            Patient = mapper.Map<Patient>(patientRequest);
            Patient.PatientId = id;
            await repository.UpdateAsync(Patient);
        }


        public async Task DeletePatientAsync([FromQuery] int id)
        {
            var Patient = await repository.GetByIdAsync(id);
            if (Patient == null)
                throw new KeyNotFoundException("Patient not found");
            await repository.DeleteAsync(id);
        }
    }
}
