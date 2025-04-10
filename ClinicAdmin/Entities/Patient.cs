using System.ComponentModel.DataAnnotations;

namespace ClinicAdmin.Entities
{
    public class Patient
    {
        public Guid patientId { get; set; }
        public DateOnly birthday { get; set; }
        public string? name { get; set; }
        public string? passportNumber { get; set; } 
        public DateTime contractDateTime { get; set; }
        public string? contractNumber { get; set; }
        public string? adress { get; set; }
        public string? phoneNumber { get; set; }
    }
}
