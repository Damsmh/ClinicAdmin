﻿using ClinicAdmin.Entities;

namespace ClinicAdmin.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment> GetByIdAsync(int id);
        Task<IEnumerable<Appointment>> GetByPatientIdAsync(int patientId);
        Task<IEnumerable<Appointment>> GetByEmployeeIdAsync(int employeeId);
        Task AddAsync(Appointment Appointment);
        Task UpdateAsync(Appointment Appointment);
        Task DeleteAsync(int id);
    }
}
