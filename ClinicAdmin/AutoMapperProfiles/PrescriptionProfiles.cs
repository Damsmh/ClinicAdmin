using AutoMapper;
using ClinicAdmin.DTO;
using ClinicAdmin.Entities;

namespace ClinicAdmin.AutoMapperProfiles
{
    public class PrescriptionProfiles : Profile
    {
        public PrescriptionProfiles()
        {
            CreateMap<Prescription, PrescriptionResponse>();
            CreateMap<PrescriptionRequest, Prescription>();
        }
    }
}
