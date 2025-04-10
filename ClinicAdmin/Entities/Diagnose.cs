namespace ClinicAdmin.Entities
{
    public class Diagnose
    {
        public Guid diagnoseId { get; set; }
        public string? name { get; set; }
        public string? code { get; set; }
        public string? content { get; set; }
    }
}
