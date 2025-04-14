using AutoMapper;
using ClinicAdmin.DTO;
using ClinicAdmin.Entities;
using ClinicAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAdmin.Services
{
    public class AppointmentService(IAppointmentRepository repository, IMapper mapper) : IAppointmentService
    {
        public async Task<IEnumerable<AppointmentResponse>> GetAllAppointmentsAsync()
        {
            var appointments = await repository.GetAllAsync();
            var AppointmentResponse = mapper.Map<IEnumerable<AppointmentResponse>>(appointments);
            return AppointmentResponse;
        }

        public async Task<AppointmentResponse> GetAppointmentByIdAsync([FromQuery] int id)
        {
            var appointment = await repository.GetByIdAsync(id);
            if (appointment == null)
                throw new KeyNotFoundException("Appointment not found");
            var AppointmentResponse = mapper.Map<AppointmentResponse>(appointment);

            return AppointmentResponse;
        }

        public async Task<IEnumerable<AppointmentResponse>> GetAppointmentByEmployeeIdAsync([FromQuery] int id)
        {
            var appointment = await repository.GetByEmployeeIdAsync(id);
            if (appointment == null)
                throw new KeyNotFoundException("Appointment not found");
            var AppointmentResponse = mapper.Map<IEnumerable<AppointmentResponse>>(appointment);

            return AppointmentResponse;
        }

        public async Task<IEnumerable<AppointmentResponse>> GetAppointmentByPatientIdAsync([FromQuery] int id)
        {
            var appointment = await repository.GetByPatientIdAsync(id);
            if (appointment == null)
                throw new KeyNotFoundException("Appointment not found");
            var AppointmentResponse = mapper.Map<IEnumerable<AppointmentResponse>>(appointment);

            return AppointmentResponse;
        }
        public async Task AddAppointmentAsync([FromBody] AppointmentRequest appointmentRequest)
        {
            var appointment = mapper.Map<Appointment>(appointmentRequest);
            appointment.AppointmentDate = DateTime.Now;
            await repository.AddAsync(appointment);
        }


        public async Task UpdateAppointmentAsync([FromQuery] int id, [FromBody] AppointmentRequest appointmentRequest)
        {
            var Appointment = await repository.GetByIdAsync(id);
            if (Appointment == null)
                throw new KeyNotFoundException("Appointment not found");
            Appointment = mapper.Map<Appointment>(appointmentRequest);
            Appointment.AppointmentId = id;
            await repository.UpdateAsync(Appointment);
        }


        public async Task DeleteAppointmentAsync([FromQuery] int id)
        {
            var Appointment = await repository.GetByIdAsync(id);
            if (Appointment == null)
                throw new KeyNotFoundException("Appointment not found");
            await repository.DeleteAsync(id);
        }
    }
}
