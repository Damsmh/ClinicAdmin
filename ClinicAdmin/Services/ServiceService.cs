using AutoMapper;
using ClinicAdmin.DTO;
using ClinicAdmin.Entities;
using ClinicAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAdmin.Services
{
    public class ServiceService(IServiceRepository repository, IMapper mapper) : IServiceService
    {
        public async Task<IEnumerable<ServiceResponse>> GetAllServicesAsync()
        {
            var services = await repository.GetAllAsync();
            var ServiceResponse = mapper.Map<IEnumerable<ServiceResponse>>(services);
            return ServiceResponse;
        }

        public async Task<ServiceResponse> GetServiceByIdAsync([FromQuery] int id)
        {
            var service = await repository.GetByIdAsync(id);
            if (service == null)
                throw new KeyNotFoundException("Service not found");
            var ServicetResponse = mapper.Map<ServiceResponse>(service);

            return ServicetResponse;
        }
        public async Task AddServiceAsync([FromBody] ServiceRequest serviceRequest)
        {
            var service = mapper.Map<Service>(serviceRequest);
            await repository.AddAsync(service);
        }


        public async Task UpdateServiceAsync([FromQuery] int id, [FromBody] ServiceRequest serviceRequest)
        {
            var Service = await repository.GetByIdAsync(id);
            if (Service == null)
                throw new KeyNotFoundException("Service not found");
            Service = mapper.Map<Service>(serviceRequest);
            Service.ServiceId = id;
            await repository.UpdateAsync(Service);
        }


        public async Task DeleteServiceAsync([FromQuery] int id)
        {
            var Service = await repository.GetByIdAsync(id);
            if (Service == null)
                throw new KeyNotFoundException("Service not found");
            await repository.DeleteAsync(id);
        }
    }
}
