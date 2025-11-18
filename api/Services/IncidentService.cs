using api.DTOs.Alert;
using api.DTOs.Incident;
using api.Models;
using api.Repositories;
using api.Services.Interfaces;

namespace api.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository _incidentRepository;
        private readonly IAlertRepository _alertRepository;

        public IncidentService(IIncidentRepository incidentRepository, IAlertRepository alertRepository)
        {
            _incidentRepository = incidentRepository;
            _alertRepository = alertRepository;
        }

        public async Task<IEnumerable<IncidentDto>> GetAllAsync()
        {
            var incidents = await _incidentRepository.GetAllAsync();
            return incidents.Select(MapToDto);
        }

        public async Task<IncidentDto?> GetByIdAsync(int id)
        {
            var incident = await _incidentRepository.GetByIdAsync(id);
            return incident == null ? null : MapToDto(incident);
        }

        
        public async Task<IncidentDto> CreateFromAlertAsync(CreateIncidentFromAlertDto dto)
        {
            var alert = await _alertRepository.GetByIdAsync(dto.AlertId);
            if (alert == null)
                throw new Exception("Alert not found.");

            var incident = new Incident
            {
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Severity = dto.Severity switch
                {
                    AlertSeverity.Low      => IncidentSeverity.Low,
                    AlertSeverity.Medium   => IncidentSeverity.Medium,
                    AlertSeverity.High     => IncidentSeverity.High,
                    AlertSeverity.Critical => IncidentSeverity.Critical,
                    _ => IncidentSeverity.Low
                },

                Status = IncidentStatus.New,
                AssignedUserId = dto.AssignedId,
                AlertId = alert.Id
            };

            await _incidentRepository.AddAsync(incident);
            return MapToDto(incident);
        }

        public async Task<bool> UpdateStatusAsync(int incidentId, string newStatus)
        {
            var incident = await _incidentRepository.GetByIdAsync(incidentId);
            if (incident == null)
                return false;

            if (!Enum.TryParse<IncidentStatus>(newStatus, out var parsedStatus))
                return false;

            incident.Status = parsedStatus;
            incident.UpdatedAt = DateTime.UtcNow;

            await _incidentRepository.UpdateAsync(incident);
            return true;
        }

        public async Task<bool> AssignUserAsync(int incidentId, int userId)
        {
            var incident = await _incidentRepository.GetByIdAsync(incidentId);
            if (incident == null)
                return false;

            incident.AssignedUserId = userId;
            incident.UpdatedAt = DateTime.UtcNow;

            await _incidentRepository.UpdateAsync(incident);
            return true;
        }

        private IncidentDto MapToDto(Incident incident)
        {
            return new IncidentDto
            {
                Id = incident.Id,
                Description = incident.Description,
                CreatedAt = incident.CreatedAt,
                UpdatedAt = incident.UpdatedAt,
                Severity = incident.Severity,
                Status = incident.Status,
                ReporterId = 0, 
                AssignedId = incident.AssignedUserId,
                AlertId = incident.AlertId
            };
        }
    }
}
