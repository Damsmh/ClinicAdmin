using AutoMapper;
using ClinicAdmin.Controllers;
using ClinicAdmin.DTO.Patient;
using ClinicAdmin.Entities;
using ClinicAdmin.Repositories;
using Microsoft.Extensions.Hosting;

namespace ClinicAdmin.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _PatientRepository;
        private readonly IMapper mapper;

        public PatientService(IPatientRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this._PatientRepository = repository;
        }

        public async Task<IEnumerable<PatientResponse>> GetAllPatientsAsync()
        {
            var Patients = await _PatientRepository.GetAllAsync();
            var PatientResponse = mapper.Map<IEnumerable<PatientResponse>>(Patients);
            return PatientResponse;
        }

        public async Task<PatientResponse> GetPatientByIdAsync(Guid id)
        {
            var Patient = await _PatientRepository.GetByIdAsync(id);
            if (Patient == null)
                throw new KeyNotFoundException("Patient not found");
            var PatientResponse = mapper.Map<PatientResponse>(Patient);

            return PatientResponse;
        }
        public async Task AddPatientAsync(PatientRequest patientRequest)
        {

            var Patient = mapper.Map<Patient>(patientRequest);
            Patient.contractDateTime = DateTime.Now;
            Patient.id = Guid.NewGuid();

            await _PatientRepository.AddAsync(Patient);
        }


        public async Task UpdatePatientAsync(Guid id, PatientRequest patientRequest)
        {
            var Patient = await _PatientRepository.GetByIdAsync(id);
            if (Patient == null)
                throw new KeyNotFoundException("Patient not found");

            Patient = mapper.Map<Patient>(patientRequest);
            Patient.id = id;
            await _PatientRepository.UpdateAsync(Patient);
        }


        public async Task DeletePatientAsync(Guid id)
        {
            var Patient = await _PatientRepository.GetByIdAsync(id);

 
            if (Patient == null)
                throw new KeyNotFoundException("Patient not found");


            await _PatientRepository.DeleteAsync(id);
        }
    }
}
