namespace ClinicAdmin.DTO
{
    public class PrescriptionRequest
    {
        public string Dosage { get; set; }
        public int DurationDays { get; set; }
        public int DiagnosisId { get; set; }
        public int MedicationId { get; set; }
    }
}
