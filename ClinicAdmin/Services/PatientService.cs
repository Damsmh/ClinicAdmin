using AutoMapper;
using ClinicAdmin.DTO;
using ClinicAdmin.Entities;
using ClinicAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAdmin.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _PatientRepository;
        private readonly IMapper mapper;

        public PatientService(IPatientRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            _PatientRepository = repository;
        }

        public async Task<IEnumerable<PatientResponse>> GetAllPatientsAsync()
        {
            var patients = await _PatientRepository.GetAllAsync();
            var PatientResponse = mapper.Map<IEnumerable<PatientResponse>>(patients);
            return PatientResponse;
        }

        public async Task<PatientResponse> GetPatientByIdAsync(int id)
        {
            var patient = await _PatientRepository.GetByIdAsync(id);
            if (patient == null)
                throw new KeyNotFoundException("Patient not found");
            var PatientResponse = mapper.Map<PatientResponse>(patient);

            return PatientResponse;
        }
        public async Task AddPatientAsync(PatientRequest patientRequest)
        {

            var patient = mapper.Map<Patient>(patientRequest);

            await _PatientRepository.AddAsync(patient);
        }


        public async Task UpdatePatientAsync(int id, [FromBody]PatientRequest patientRequest)
        {
            var Patient = await _PatientRepository.GetByIdAsync(id);
            if (Patient == null)
                throw new KeyNotFoundException("Patient not found");

            Patient = mapper.Map<Patient>(patientRequest);
            Patient.PatientId = id;
            await _PatientRepository.UpdateAsync(Patient);
        }


        public async Task DeletePatientAsync(int id)
        {
            var Patient = await _PatientRepository.GetByIdAsync(id);

 
            if (Patient == null)
                throw new KeyNotFoundException("Patient not found");


            await _PatientRepository.DeleteAsync(id);
        }
    }
}
