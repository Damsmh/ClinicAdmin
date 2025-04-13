using ClinicAdmin.Data;
using ClinicAdmin.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ClinicAdmin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Patient> Patients { get; set; }

        public async Task OnGetAsync()
        {
            Patients = await _context.Patients.ToListAsync();
        }
    }
}
