using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicAdmin.Entities
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; } // 'M', 'F', 'O'
        public string PassportNumber { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; } // Опционально
        public string Address { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
