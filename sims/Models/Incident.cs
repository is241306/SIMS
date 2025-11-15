namespace sims.Models;

public enum IncidentSeverity
{
    Low,
    Medium,
    High,
    Critical
}

public enum IncidentStatus 
{
    Open,
    Resolved,
    InProgress,
    Escalated
}

public class Incident 
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public IncidentSeverity Severity { get; set; } = IncidentSeverity.Low;
    public IncidentStatus Status { get; set; } = IncidentStatus.Open;
    public string SystemName { get; set; } = "";
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Updated { get; set; } = DateTime.UtcNow;
    public DateTime? ClosedAt { get; set; } 
    public int ReporterId { get; set; }
    public int? AssignedId { get; set; }
}