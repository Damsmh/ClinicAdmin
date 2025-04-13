namespace ClinicAdmin.DTO
{
    public class AppointmentServiceResponse
    {
        public int AppointmentServiceId { get; set; }
        public string? Result { get; set; }
        public int AppointmentId { get; set; }
        public int ServiceId { get; set; }
    }
}
