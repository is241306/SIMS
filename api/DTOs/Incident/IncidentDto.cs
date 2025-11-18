using api.DTOs.Alert;
using api.Models;

namespace api.DTOs.Incident
{
    public class IncidentDto
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }

        public IncidentStatus Status { get; set; }
        public IncidentSeverity Severity { get; set; }

        public int ReporterId { get; set; }
        public int? AssignedId { get; set; }

        public int? AlertId { get; set; }

        public List<AlertDto> Alerts { get; set; } = new();
    }
}