using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;

namespace api.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly SimsContext _context;

    public UserRoleRepository(SimsContext context)
    {
        _context = context;
    }

    public async Task AddAsync(UserRole userRole)
    {
        await _context.UserRoles.AddAsync(userRole);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(UserRole userRole)
    {
        _context.UserRoles.Remove(userRole);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Role>> GetRolesForUserAsync(int userId)
    {
        return await _context.UserRoles
            .Where(ur => ur.UserId == userId)
            .Include(ur => ur.Role)
            .Select(ur => ur.Role)
            .ToListAsync();
    }
}