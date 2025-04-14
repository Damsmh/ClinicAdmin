using ClinicAdmin.Entities;

namespace ClinicAdmin.DTO
{
    public class PatientResponse
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public DateOnly BirthDate { get; set; }
        public char Gender { get; set; } // 'M', 'F', 'O'
        public string PassportNumber { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; } // Опционально
        public string Address { get; set; }
    }
}
