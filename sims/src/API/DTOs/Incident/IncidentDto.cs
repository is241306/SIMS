using sims.API.DTOs.Alert;

namespace sims.API.DTOs.Incident
{

    public class IncidentDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; } = "Open"; // Open, InProgress, Resolved
        public string Severity { get; set; } = "Low"; // Low, Medium, High, Critical
        public int? AssignedUserId { get; set; }
        
        public List<AlertDto> Alerts { get; set; } = new List<AlertDto>();
    }
}