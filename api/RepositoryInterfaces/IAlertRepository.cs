using api.Models;

namespace api.Repositories
{
    public interface IAlertRepository
    {
        Task<Alert?> GetByIdAsync(int id);
        Task<IReadOnlyList<Alert>> GetAllAsync();
        Task AddAsync(Alert alert);
        Task DeleteAsync(Alert alert);
    }
}