using Microsoft.EntityFrameworkCore;
using ClinicAdmin.Data;
using ClinicAdmin.Entities;
using Npgsql;
using ClinicAdmin.Utils;

namespace ClinicAdmin.Repositories
{

    public class PatientRepository(ApplicationDbContext context) : IPatientRepository
    {
        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await context.Patients
                .FromSqlRaw($"""SELECT * FROM "Patients" """)
                .ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            var PatientId = new NpgsqlParameter("PatientId", id);
            return await context.Patients
                .FromSqlRaw($"""SELECT * FROM "Patients" WHERE "PatientId" = @PatientId""", PatientId)
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(Patient patient)
        {
            var parameters = RepositoryUtils.ParametersGenerator(patient);
            await context.Database.ExecuteSqlRawAsync($"""
                INSERT INTO "Patients" ("BirthDate", "FullName", "PassportNumber", "Address", "Phone", "Email", "Gender")
                VALUES (@BirthDate, @FullName, @PassportNumber, @Address, @Phone, @Email, @Gender)
                """, parameters);
        }

        public async Task UpdateAsync(Patient patient)
        {
            var PatientId = new NpgsqlParameter("PatientId", patient.PatientId);
            var _patient = await context.Patients.FromSqlRaw($"""SELECT * FROM "Patients" WHERE "PatientId" = @PatientId""", PatientId).FirstOrDefaultAsync();
            
            if (_patient != null)
            {
                var parameters = RepositoryUtils.ParametersGenerator(patient);
                await context.Database.ExecuteSqlRawAsync($"""
                    UPDATE "Patients"
                    SET "BirthDate" = @BirthDate, "FullName" = @FullName, "PassportNumber" = @PassportNumber, "Address" = @Address, "Phone" = @Phone, "Email" = @Email, "Gender" = @Gender
                    WHERE "PatientId" = @PatientId
                    """, parameters);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var PatientId = new NpgsqlParameter("PatientId", id);
            var patient = await context.Patients.FromSqlRaw($"""SELECT * FROM "Patients" WHERE "PatientId" = @PatientId""", PatientId).FirstOrDefaultAsync();
            if (patient != null)
                await context.Database.ExecuteSqlRawAsync($"""DELETE FROM "Patients" WHERE "PatientId" = @PatientId""", PatientId);
        }
    }
}
