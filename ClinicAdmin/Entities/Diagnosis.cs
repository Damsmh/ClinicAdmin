using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicAdmin.Entities
{
    public class Diagnosis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiagnosisId { get; set; }
        [Required] public string DiagnosisCode { get; set; }
        [Required] public string Description { get; set; }
        [Required] public string Recommendations { get; set; }
        [Required] public int AppointmentId { get; set; }

        public Appointment Appointment { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
