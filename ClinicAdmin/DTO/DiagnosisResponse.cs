using System.ComponentModel.DataAnnotations;

namespace ClinicAdmin.DTO
{
    public class DiagnosisResponse
    {
        public int DiagnosisId { get; set; }
        public string DiagnosisCode { get; set; }
        public string Description { get; set; }
        public string Recommendations { get; set; }
        public int AppointmentId { get; set; }
    }
}
