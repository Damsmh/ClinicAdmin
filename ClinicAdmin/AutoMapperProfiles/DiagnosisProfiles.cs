using AutoMapper;
using ClinicAdmin.DTO;
using ClinicAdmin.Entities;

namespace ClinicAdmin.AutoMapperProfiles
{
    public class DiagnosisProfiles : Profile
    {
        public DiagnosisProfiles()
        {
            CreateMap<Diagnosis, DiagnosisResponse>();
            CreateMap<DiagnosisRequest, Diagnosis>();
        }
    }
}
