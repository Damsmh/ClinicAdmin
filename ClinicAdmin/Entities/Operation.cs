using System.ComponentModel.DataAnnotations;

namespace ClinicAdmin.Entities
{
    public class Operation
    {
        public Guid operationId { get; set; }
        public Guid patientId { get; set; }
        public Guid employeeId { get; set; }
        public Guid serviceId { get; set; }
        public Patient? patient { get; set; }
        public Employee? employee { get; set; }
        public Service? service { get; set; } 
        public DateTime operationTime { get; set; }
        public string? content { get; set; }
    }
}
