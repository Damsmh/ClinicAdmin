using AutoMapper;
using ClinicAdmin.DTO;
using ClinicAdmin.Repositories;
using ClinicAdmin.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAdmin.Services
{
    public class AppointmentServiceService(IAppointmentServiceRepository repository, IMapper mapper) : IAppointmentServiceService
    {
        public async Task<IEnumerable<AppointmentServiceResponse>> GetAllAppointmentServicesAsync()
        {
            var appointmentServices = await repository.GetAllAsync();
            var AppointmentServiceResponse = mapper.Map<IEnumerable<AppointmentServiceResponse>>(appointmentServices);
            return AppointmentServiceResponse;
        }

        public async Task<AppointmentServiceResponse> GetAppointmentServiceByIdAsync([FromQuery] int id)
        {
            var appointmentService = await repository.GetByIdAsync(id);
            if (appointmentService == null)
                throw new KeyNotFoundException("AppointmentService not found");
            var AppointmentServiceResponse = mapper.Map<AppointmentServiceResponse>(appointmentService);

            return AppointmentServiceResponse;
        }

        public async Task<IEnumerable<AppointmentServiceResponse>> GetAppointmentServiceByAppointmentIdAsync([FromQuery] int id)
        {
            var appointmentService = await repository.GetByAppointmentIdAsync(id);
            if (appointmentService == null)
                throw new KeyNotFoundException("AppointmentService not found");
            var AppointmentServiceResponse = mapper.Map<IEnumerable<AppointmentServiceResponse>>(appointmentService);

            return AppointmentServiceResponse;
        }

        public async Task<IEnumerable<AppointmentServiceResponse>> GetAppointmentServiceByServiceIdAsync([FromQuery] int id)
        {
            var appointmentService = await repository.GetByServiceIdAsync(id);
            if (appointmentService == null)
                throw new KeyNotFoundException("AppointmentService not found");
            var AppointmentServiceResponse = mapper.Map<IEnumerable<AppointmentServiceResponse>>(appointmentService);

            return AppointmentServiceResponse;
        }
        public async Task AddAppointmentServiceAsync([FromBody] AppointmentServiceRequest appointmentServiceRequest)
        {
            var appointmentService = mapper.Map<Entities.AppointmentService>(appointmentServiceRequest);
            await repository.AddAsync(appointmentService);
        }


        public async Task UpdateAppointmentServiceAsync([FromQuery] int id, [FromBody] AppointmentServiceRequest appointmentServiceRequest)
        {
            var AppointmentService = await repository.GetByIdAsync(id);
            if (AppointmentService == null)
                throw new KeyNotFoundException("AppointmentService not found");
            AppointmentService = mapper.Map<Entities.AppointmentService>(appointmentServiceRequest);
            AppointmentService.AppointmentServiceId = id;
            await repository.UpdateAsync(AppointmentService);
        }


        public async Task DeleteAppointmentServiceAsync([FromQuery] int id)
        {
            var AppointmentService = await repository.GetByIdAsync(id);
            if (AppointmentService == null)
                throw new KeyNotFoundException("AppointmentService not found");
            await repository.DeleteAsync(id);
        }
    }
}
