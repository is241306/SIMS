using api.DTOs.Alert;
using api.Models;
using api.Repositories;
using api.Services.Interfaces;

namespace api.Services
{
    public class AlertService : IAlertService
    {
        private readonly IAlertRepository _alertRepository;
        private readonly IIncidentRepository _incidentRepository;

        public AlertService(IAlertRepository alertRepository, IIncidentRepository incidentRepository)
        {
            _alertRepository = alertRepository;
            _incidentRepository = incidentRepository;
        }

        public async Task<IEnumerable<AlertDto>> GetAllAsync()
        {
            var alerts = await _alertRepository.GetAllAsync();
            return alerts.Select(MapToDto);
        }

        public async Task<AlertDto?> GetByIdAsync(int id)
        {
            var alert = await _alertRepository.GetByIdAsync(id);
            if (alert == null) 
                return null;
            
            return MapToDto(alert);
        }

        public async Task<AlertDto> CreateAsync(AlertDto dto)
        {
            var alert = new Alert
            {
                AlertExternalId = dto.AlertId,
                Description = dto.Description,
                Host = dto.Host,
                User = dto.User,
                IP = dto.IP,
                AlertLevel = dto.AlertLevel,
                Timestamp = dto.Timestamp,
                AssignedToUserId = dto.AssignedToUserId,
                Status = dto.Status,
                Escalate = dto.Escalate
            };

            await _alertRepository.AddAsync(alert);
            return MapToDto(alert);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var alert = await _alertRepository.GetByIdAsync(id);
            if (alert == null)
                return false;

            await _alertRepository.DeleteAsync(alert);
            return true;
        }

        public async Task<bool> EscalateAsync(int id)
        {
            var alert = await _alertRepository.GetByIdAsync(id);
            if (alert == null)
                return false;

            alert.Status = AlertStatus.Escalated.ToString();
            alert.Escalate = true;

            await _alertRepository.UpdateAsync(alert);
            return true;
        }

        public async Task<bool> CreateIncidentFromAlertAsync(CreateIncidentFromAlertDto dto)
        {
            var alert = await _alertRepository.GetByIdAsync(dto.AlertId);
            if (alert == null)
                return false;

            var incident = new Incident
            {
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
        
                Severity = dto.Severity switch
                {
                    AlertSeverity.Low => IncidentSeverity.Low,
                    AlertSeverity.Medium => IncidentSeverity.Medium,
                    AlertSeverity.High => IncidentSeverity.High,
                    AlertSeverity.Critical => IncidentSeverity.Critical,
                    _ => IncidentSeverity.Low
                },

                Status = IncidentStatus.New,
                AssignedUserId = dto.AssignedId,
                AlertId = alert.Id
            };

            await _incidentRepository.AddAsync(incident);

            return true;
        }

        public async Task<int?> ConvertToIncidentAsync(int alertId)
        {
            var alert = await _alertRepository.GetByIdAsync(alertId);
            if (alert == null)
                return null;

            var severity = alert.AlertLevel switch
            {
                1 => IncidentSeverity.Low,
                2 => IncidentSeverity.Medium,
                3 => IncidentSeverity.High,
                4 => IncidentSeverity.Critical,
                _ => IncidentSeverity.Medium
            };

            var incident = new Incident
            {
                Description = $"{alert.Description} (from alert {alert.AlertExternalId})",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Severity = severity,
                Status = IncidentStatus.New,
                AlertId = alert.Id
            };

            await _incidentRepository.AddAsync(incident);

            alert.Status = "Resolved";
            await _alertRepository.UpdateAsync(alert);

            return incident.Id;
        }

        private AlertDto MapToDto(Alert alert)
        {
            return new AlertDto
            {
                Id = alert.Id,
                AlertId = alert.AlertExternalId,
                Description = alert.Description,
                Host = alert.Host,
                User = alert.User,
                IP = alert.IP,
                AlertLevel = alert.AlertLevel,
                Timestamp = alert.Timestamp,
                AssignedToUserId = alert.AssignedToUserId,
                Status = alert.Status,
                Escalate = alert.Escalate
            };
        }
    }
}
