using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace ClinicAdmin.Entities
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } // "Запланирован", "Завершён", "Отменён"
        public string? Notes { get; set; } // Опционально

        public int PatientId { get; set; }
        public int EmployeeId { get; set; }

        public Patient Patient { get; set; }
        public Employee Employee { get; set; }
        public Diagnosis Diagnosis { get; set; }
        public ICollection<AppointmentService> AppointmentServices { get; set; }
    }
}
