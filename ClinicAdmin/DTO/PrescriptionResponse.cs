namespace ClinicAdmin.DTO
{
    public class PrescriptionResponse
    {
        public int PrescriptionId { get; set; }
        public string Dosage { get; set; }
        public int DurationDays { get; set; }
        public int DiagnosisId { get; set; }
        public int MedicationId { get; set; }
    }
}
