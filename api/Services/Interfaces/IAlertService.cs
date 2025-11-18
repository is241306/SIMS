using api.DTOs.Alert;

namespace api.Services.Interfaces
{
    public interface IAlertService
    {
        Task<IEnumerable<AlertDto>> GetAllAsync();
        Task<AlertDto?> GetByIdAsync(int id);
        Task<AlertDto> CreateAsync(AlertDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> CreateIncidentFromAlertAsync(CreateIncidentFromAlertDto dto);
        Task<bool> EscalateAsync(int id);
    }
}