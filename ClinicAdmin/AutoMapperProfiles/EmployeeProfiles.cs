using AutoMapper;
using ClinicAdmin.DTO;
using ClinicAdmin.Entities;

namespace ClinicAdmin.AutoMapperProfiles
{
    public class EmployeeProfiles : Profile

    {
        public EmployeeProfiles()
        {
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<EmployeeRequest, Employee>();
        }
    }
}
