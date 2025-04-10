using Microsoft.EntityFrameworkCore;
using ClinicAdmin.Entities;

namespace ClinicAdmin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Patient> patients { get; set; }
        
    }
}
