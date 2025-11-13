namespace sims.API.DTOs.Alert
{
    public class AlertDto
    {
        public string AlertId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public string IP { get; set; } = string.Empty;
        public int AlertLevel { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        
        public int? AssignedToUserId { get; set; }
        public string Status { get; set; } = "New";
        public bool Escalate { get; set; } = false;
    }
}