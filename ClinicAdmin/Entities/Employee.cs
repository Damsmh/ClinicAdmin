namespace ClinicAdmin.Entities
{
    public class Employee
    {
        public Guid employeeId { get; set; }
        public DateOnly birthday { get; set; }
        public string? name { get; set; }
        public string? post { get; set; }
        public string? passportSN { get; set; }
    }
}
