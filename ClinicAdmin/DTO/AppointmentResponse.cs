namespace ClinicAdmin.DTO
{
    public class AppointmentResponse
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string? Notes { get; set; }

        public int PatientId { get; set; }
        public int EmployeeId { get; set; }
    }
}
