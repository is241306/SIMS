using api.Models;
namespace api.DTOs.Alert;

public class CreateIncidentFromAlertDto
{
    
    public int AlertId { get; set; }
    public string Source { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public AlertSeverity Severity { get; set; }  
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public string Description { get; set; } = string.Empty;
    public int ReporterId { get; set; }            
    public int? AssignedId { get; set; }       

}