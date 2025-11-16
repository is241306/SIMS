using api.Models;
using api.DTOs.Alert;

namespace api.DTOs.Incident
{

    public class IncidentDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = "";
        
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime? ClosedAt { get; set; }

        public IncidentStatus Status { get; set; } 
        public IncidentSeverity Severity { get; set; }
        
        public int ReporterId { get; set; }
        public int? AssignedId { get; set; }
        
        public List<AlertDto> Alerts { get; set; } = new List<AlertDto>();
    }
}