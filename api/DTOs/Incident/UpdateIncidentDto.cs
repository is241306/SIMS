namespace api.DTOs.Incident
{
    public class UpdateIncidentDto
    {
        public string Description { get; set; } = string.Empty;
        public string Severity { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int? AssignedId { get; set; }
    }
}
