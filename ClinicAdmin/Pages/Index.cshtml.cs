using ClinicAdmin.Data;
using ClinicAdmin.Entities;
using ClinicAdmin.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ClinicAdmin.Pages
{
    public class IndexModel(ApplicationDbContext context) : PageModel
    {
        public List<Patient> Patients { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Diagnosis> Diagnoses { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Service> Services { get; set; }
        public List<Prescription> Prescriptions { get; set; }
        public List<Medication> Medications { get; set; }
        public List<AppointmentService> AppointmentServices { get; set; } 
        public async Task OnGet()
        {
            Patients = await context.Patients
                .FromSqlRaw($"""SELECT * FROM "Patients" """)
                .ToListAsync();
            Employees = await context.Employees
                .FromSqlRaw($"""SELECT * FROM "Employees" """)
                .ToListAsync();
            Diagnoses = await context.Diagnoses
                .FromSqlRaw($"""SELECT * FROM "Diagnoses" """)
                .ToListAsync();
            Appointments = await context.Appointments
                .FromSqlRaw($"""SELECT * FROM "Appointments" """)
                .ToListAsync();
            Services = await context.Services
                .FromSqlRaw($"""SELECT * FROM "Services" """)
                .ToListAsync();
            Prescriptions = await context.Prescriptions
                .FromSqlRaw($"""SELECT * FROM "Prescriptions" """)
                .ToListAsync();
            Medications = await context.Medications
                .FromSqlRaw($"""SELECT * FROM "Medications" """)
                .ToListAsync();
            AppointmentServices = await context.AppointmentServices
                .FromSqlRaw($"""SELECT * FROM "AppointmentServices" """)
                .ToListAsync();
        }
    }
}
