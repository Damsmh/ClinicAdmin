using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicAdmin.Entities
{
    public class AppointmentService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentServiceId { get; set; }
        public string? Result { get; set; } // Результат выполнения услуги

        public int AppointmentId { get; set; }
        public int ServiceId { get; set; }

        public Appointment Appointment { get; set; }
        public Service Service { get; set; }
    }
}
