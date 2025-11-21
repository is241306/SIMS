using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;

namespace api.Repositories;

public class IncidentRepository : IIncidentRepository
{
    private readonly SimsContext _context;

    public IncidentRepository(SimsContext context)
    {
        _context = context;
    }

    public async Task<Incident?> GetByIdAsync(int id)
    {
        return await _context.Incidents
            .Include(i => i.AssignedUser)
            .Include(i => i.Alert)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<IReadOnlyList<Incident>> GetAllAsync()
    {
        return await _context.Incidents
            .Include(i => i.AssignedUser)
            .Include(i => i.Alert)
            .ToListAsync();
    }

    public async Task AddAsync(Incident incident)
    {
        await _context.Incidents.AddAsync(incident);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Incident incident)
    {
        _context.Incidents.Update(incident);
        await _context.SaveChangesAsync();
    }
}