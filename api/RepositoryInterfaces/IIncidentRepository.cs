using api.Models;

namespace api.Repositories
{
    public interface IIncidentRepository
    {
        Task<Incident?> GetByIdAsync(int id);
        Task<IReadOnlyList<Incident>> GetAllAsync();
        Task AddAsync(Incident incident);
        Task UpdateAsync(Incident incident);
    }
}