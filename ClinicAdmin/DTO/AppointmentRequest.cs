namespace ClinicAdmin.DTO
{
    public class AppointmentRequest
    {
        public string Status { get; set; }
        public string? Notes { get; set; }
        public int PatientId { get; set; }
        public int EmployeeId { get; set; }
    }
}
