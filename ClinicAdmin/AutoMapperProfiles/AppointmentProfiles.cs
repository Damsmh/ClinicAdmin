using AutoMapper;
using ClinicAdmin.DTO;
using ClinicAdmin.Entities;

namespace ClinicAdmin.AutoMapperProfiles
{
    public class AppointmentProfiles : Profile
    {
        public AppointmentProfiles()
        {
            CreateMap<Appointment, AppointmentResponse>();
            CreateMap<AppointmentRequest, Appointment>();
        }
    }
}
