using api.Models;

namespace api.Repositories
{
    public interface IUserRoleRepository
    {
        Task AddAsync(UserRole userRole);
        Task RemoveAsync(UserRole userRole);
        Task<IReadOnlyList<Role>> GetRolesForUserAsync(int userId);
    }
}