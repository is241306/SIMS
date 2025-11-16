namespace api.Models;

public enum AlertSeverity
{
    Low,
    Medium,
    High,
    Critical
}

public enum AlertStatus
{
    New,
    Open,
    InProgress,
    Resolved,
    Escalated
}

public class Alert
{
    public int Id { get; set; }

    // Correlate with SIEM / external system
    public string AlertExternalId { get; set; } = string.Empty; // maps from AlertDto.AlertId

    public string Description { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string IP { get; set; } = string.Empty;
    public int AlertLevel { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public int? AssignedToUserId { get; set; }
    public User? AssignedToUser { get; set; }

    public string Status { get; set; } = "New"; // maps from AlertDto.Status
    public bool Escalate { get; set; }

    public ICollection<Incident> Incidents { get; set; } = new List<Incident>();
}