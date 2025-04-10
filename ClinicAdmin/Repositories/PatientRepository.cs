using Microsoft.EntityFrameworkCore;
using ClinicAdmin.Data;
using ClinicAdmin.Entities;
using Npgsql;

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
            return await _context.Patients
                .FromSqlRaw($"""SELECT * FROM "Patients" """)
                .ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            var PatientId = new NpgsqlParameter("PatientId", id);
            return await _context.Patients
                .FromSqlRaw($"""SELECT * FROM "Patients" WHERE "PatientId" = @PatientId""", PatientId)
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
            parameters.RemoveAt(parameters.Count - 1);

            await _context.Database.ExecuteSqlRawAsync($"""
                INSERT INTO "Patients" ("BirthDate", "FullName", "PassportNumber", "Address", "Phone", "Email", "Gender")
                VALUES (@BirthDate, @FullName, @PassportNumber, @Address, @Phone, @Email, @Gender)
                """, parameters);
        }

        public async Task UpdateAsync(Patient patient)
        {
            var PatientId = new NpgsqlParameter("PatientId", patient.PatientId);
            var _patient = await _context.Patients.FromSqlRaw($"""SELECT * FROM "Patients" WHERE "PatientId" = @PatientId""", PatientId).FirstOrDefaultAsync();
            
            if (_patient != null)
            {
                CopyAll(patient, _patient);
                var type = typeof(Patient);
                List<NpgsqlParameter> parameters = [];
                foreach (var Prop in type.GetProperties())
                {
                    parameters.Add(new NpgsqlParameter($"{Prop.Name}", Prop.GetValue(_patient)));
                }
                await _context.Database.ExecuteSqlRawAsync($"""
                    UPDATE "Patients"
                    SET "BirthDate" = @BirthDate, "FullName" = @FullName, "PassportNumber" = @PassportNumber, "Address" = @Address, "Phone" = @Phone, "Email" = @Email, "Gender" = @Gender
                    WHERE "PatientId" = @PatientId
                    """, parameters);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var PatientId = new NpgsqlParameter("PatientId", id);
            var patient = await _context.Patients.FromSqlRaw($"""SELECT * FROM "Patients" WHERE "PatientId" = @PatientId""", PatientId).FirstOrDefaultAsync();

            if (patient != null)
            {
                await _context.Database.ExecuteSqlRawAsync($"""DELETE FROM "Patients" WHERE "PatientId" = @PatientId""", PatientId);
            }
        }
    }
}
