using AutoMapper;
using ClinicAdmin.DTO;
using ClinicAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAdmin.Services
{
    public class DiagnosisService(IDiagnosisRepository repository, IMapper mapper) : IDiagnosisService
    {
        public async Task<IEnumerable<DiagnosisResponse>> GetAllDiagnosesAsync()
        {
            var diagnosisServices = await repository.GetAllAsync();
            var DiagnosisResponse = mapper.Map<IEnumerable<DiagnosisResponse>>(diagnosisServices);
            return DiagnosisResponse;
        }

        public async Task<DiagnosisResponse> GetDiagnosisByIdAsync([FromQuery] int id)
        {
            var diagnosisService = await repository.GetByIdAsync(id);
            if (diagnosisService == null)
                throw new KeyNotFoundException("Diagnosis not found");
            var DiagnosisResponse = mapper.Map<DiagnosisResponse>(diagnosisService);

            return DiagnosisResponse;
        }

        public async Task<IEnumerable<DiagnosisResponse>> GetDiagnosesByAppointmentIdAsync([FromQuery] int id)
        {
            var diagnosisService = await repository.GetByAppointmentIdAsync(id);
            if (diagnosisService == null)
                throw new KeyNotFoundException("Diagnosis not found");
            var DiagnosisResponse = mapper.Map<IEnumerable<DiagnosisResponse>>(diagnosisService);

            return DiagnosisResponse;
        }

        public async Task AddDiagnosisAsync([FromBody] DiagnosisRequest diagnosisServiceRequest)
        {
            var diagnosisService = mapper.Map<Entities.Diagnosis>(diagnosisServiceRequest);
            await repository.AddAsync(diagnosisService);
        }


        public async Task UpdateDiagnosisAsync([FromQuery] int id, [FromBody] DiagnosisRequest diagnosisServiceRequest)
        {
            var Diagnosis = await repository.GetByIdAsync(id);
            if (Diagnosis == null)
                throw new KeyNotFoundException("Diagnosis not found");
            Diagnosis = mapper.Map<Entities.Diagnosis>(diagnosisServiceRequest);
            Diagnosis.DiagnosisId = id;
            await repository.UpdateAsync(Diagnosis);
        }


        public async Task DeleteDiagnosisAsync([FromQuery] int id)
        {
            var Diagnosis = await repository.GetByIdAsync(id);
            if (Diagnosis == null)
                throw new KeyNotFoundException("Diagnosis not found");
            await repository.DeleteAsync(id);
        }
    }
}
