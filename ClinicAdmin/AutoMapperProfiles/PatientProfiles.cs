using AutoMapper;
using ClinicAdmin.DTO;
using ClinicAdmin.Entities;
using Microsoft.Extensions.Hosting;

namespace ClinicAdmin.AutoMapperProfiles
{
    public class PatientProfiles : Profile
    {
        public PatientProfiles()
        {
            CreateMap<Patient, PatientResponse>();
            CreateMap<PatientRequest, Patient>();
        }
    }
}
