using api.DTOs.Incident;
using api.DTOs.Alert;

namespace api.Services.Interfaces
{
    public interface IIncidentService
    {
        Task<IEnumerable<IncidentDto>> GetAllAsync();
        Task<IncidentDto?> GetByIdAsync(int id);
        Task<IncidentDto> CreateAsync(CreateIncidentDto dto);
        Task<bool> UpdateAsync(int id, UpdateIncidentDto dto);
        Task<IncidentDto> CreateFromAlertAsync(CreateIncidentFromAlertDto dto);
        Task<bool> UpdateStatusAsync(int incidentId, string newStatus);
        Task<bool> AssignUserAsync(int incidentId, int userId);
    }
}