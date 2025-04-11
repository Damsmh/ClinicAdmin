using AutoMapper;
using ClinicAdmin.DTO;
using ClinicAdmin.Entities;

namespace ClinicAdmin.AutoMapperProfiles
{
    public class MedicationProfiles : Profile
    {
        public MedicationProfiles()
        {
            CreateMap<Medication, MedicationResponse>();
            CreateMap<MedicationRequest, Medication>();
        }
    }
}
