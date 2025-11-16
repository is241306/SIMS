namespace api.Models;

public enum Severity
{
    Low,
    Medium,
    High,
    Critical
}

public enum IncidentStatus
{
    New,
    Open,
    InProgress,
    Resolved,
    Escalated
}

public class Incident
{
    public int Id { get; set; }

    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public IncidentStatus Status { get; set; } = IncidentStatus.Open;
    public Severity Severity { get; set; } = Severity.Low;

    public int? AssignedUserId { get; set; }
    public User? AssignedUser { get; set; }

    // Simplest: one main Alert; DTO uses List<AlertDto> but you can start with first/primary
    public int? AlertId { get; set; }
    public Alert? Alert { get; set; }
}