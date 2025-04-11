using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicAdmin.Entities
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DurationMinutes { get; set; }

        public ICollection<AppointmentService> AppointmentServices { get; set; }
    }
}
