using AutoMapper;
using ClinicAdmin.DTO;
using ClinicAdmin.Entities;

namespace ClinicAdmin.AutoMapperProfiles
{
    public class AppointmentServiceProfiles : Profile
    {
        public AppointmentServiceProfiles()
        {
            CreateMap<AppointmentService, AppointmentServiceResponse>();
            CreateMap<AppointmentServiceRequest, AppointmentService>();
        }
    }
}
