using Microsoft.EntityFrameworkCore;
using ClinicAdmin.Data;
using ClinicAdmin.Entities;
using Microsoft.Data.SqlClient;
using Npgsql;
using Microsoft.AspNetCore.Components;

namespace ClinicAdmin.Repositories
{

    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;
        private ILogger<PatientRepository> _logger;
        public void CopyAll<T>(T source, T target)
        {
            var type = typeof(T);
            foreach (var sourceProperty in type.GetProperties())
            {
                var targetProperty = type.GetProperty(sourceProperty.Name);
                targetProperty.SetValue(target, sourceProperty.GetValue(source, null), null);
            }
            foreach (var sourceField in type.GetFields())
            {
                var targetField = type.GetField(sourceField.Name);
                targetField.SetValue(target, sourceField.GetValue(source));
            }
        }

        public PatientRepository(ApplicationDbContext context, ILogger<PatientRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.patients
                .FromSqlRaw($"SELECT * FROM patients")
                .ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(Guid id)
        {
            var PatientId = new NpgsqlParameter("PatientId", id);
            return await _context.patients
                .FromSqlRaw($"SELECT * FROM patients WHERE id = @PatientId", PatientId)
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(Patient patient)
        {
            //Ебический deгенератор параметров для вставки в таблицу.
            var type = typeof(Patient);
            List<NpgsqlParameter> parameters = [];
            foreach (var Prop in type.GetProperties())
            {
                parameters.Add(new NpgsqlParameter($"{Prop.Name}", Prop.GetValue(patient)));
            }

            await _context.Database.ExecuteSqlRawAsync($"""
                INSERT INTO patients (id, birthday, name, "passportNumber", "contractDateTime", "contractNumber", adress, "phoneNumber")
                VALUES (@id, @birthday, @name, @passportNumber, @contractDateTime, @contractNumber, @adress, @phoneNumber)
                """, parameters);
        }

        public async Task UpdateAsync(Patient patient)
        {
            var PatientId = new NpgsqlParameter("PatientId", patient.id);
            var _patient = await _context.patients.FromSqlRaw($"""SELECT * FROM patients WHERE id = @PatientId""", PatientId).FirstOrDefaultAsync();
            
            if (_patient != null)
            {
                var contractDate = _patient.contractDateTime;
                CopyAll(patient, _patient);
                _patient.contractDateTime = contractDate;
                var type = typeof(Patient);
                List<NpgsqlParameter> parameters = [];
                foreach (var Prop in type.GetProperties())
                {
                    parameters.Add(new NpgsqlParameter($"{Prop.Name}", Prop.GetValue(_patient)));
                }
                await _context.Database.ExecuteSqlRawAsync($"""
                    UPDATE patients
                    SET "birthday" = @birthday, "name" = @name, "passportNumber" = @passportNumber, "contractDateTime" = @contractDateTime, "contractNumber" = @contractNumber, "adress" = @adress, "phoneNumber" = @phoneNumber
                    WHERE id = @id
                    """, parameters);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var PatientId = new NpgsqlParameter("id", id);
            var patient = await _context.patients.FromSqlRaw($"""SELECT * FROM patients WHERE id = @id""", PatientId).FirstOrDefaultAsync();

            if (patient != null)
            {
                await _context.Database.ExecuteSqlRawAsync($"DELETE FROM patients WHERE id = @id", PatientId);
            }
        }
    }
}
