using api.Models;

namespace api.Repositories

{
    public interface IRoleRepository
    {
        Task<Role?> GetByIdAsync(int id);
        Task<Role?> GetByNameAsync(string name);
        Task<IReadOnlyList<Role>> GetAllAsync();
    }
}