namespace ClinicAdmin.Entities
{
    public class Reception
    {
        public Guid id { get; set; }
        public Guid patientId { get; set; }
        public Guid employeeId { get; set; }
        public Guid serviceId { get; set; }
        public Patient? patient { get; set; }
        public Employee? employee { get; set; }
        public Service? service { get; set; }
        public DateTime visitingDate { get; set; }
    }
}
