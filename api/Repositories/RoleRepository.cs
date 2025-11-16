using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;

namespace api.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly SimsContext _context;

    public RoleRepository(SimsContext context)
    {
        _context = context;
    }

    public async Task<Role?> GetByIdAsync(int id)
    {
        return await _context.Roles
            .Include(r => r.UserRoles)
            .ThenInclude(ur => ur.User)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Role?> GetByNameAsync(string name)
    {
        return await _context.Roles
            .Include(r => r.UserRoles)
            .ThenInclude(ur => ur.User)
            .FirstOrDefaultAsync(r => r.Name == name);
    }

    public async Task<IReadOnlyList<Role>> GetAllAsync()
    {
        return await _context.Roles
            .Include(r => r.UserRoles)
            .ThenInclude(ur => ur.User)
            .ToListAsync();
    }
}