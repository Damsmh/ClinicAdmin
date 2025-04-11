using AutoMapper;
using ClinicAdmin.DTO;
using ClinicAdmin.Entities;

namespace ClinicAdmin.AutoMapperProfiles
{
    public class ServiceProfiles : Profile
    {
        public ServiceProfiles()
        {
            CreateMap<Service, ServiceResponse>();
            CreateMap<ServiceRequest, Service>();
        }
    }
}
