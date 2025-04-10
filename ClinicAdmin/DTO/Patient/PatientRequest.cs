namespace ClinicAdmin.DTO.Patient
{
    public class PatientRequest
    {
        public DateOnly birthday { get; set; }
        public string? name { get; set; }
        public string? passportNumber { get; set; }
        public string? contractNumber { get; set; }
        public string? adress { get; set; }
        public string? phoneNumber { get; set; }
    }
}
