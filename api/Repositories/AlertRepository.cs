using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;

namespace api.Repositories;

public class AlertRepository : IAlertRepository
{
    private readonly SimsContext _context;

    public AlertRepository(SimsContext context)
    {
        _context = context;
    }

    public async Task<Alert?> GetByIdAsync(int id)
    {
        return await _context.Alerts
            .Include(a => a.Incidents)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IReadOnlyList<Alert>> GetAllAsync()
    {
        return await _context.Alerts
            .Include(a => a.Incidents)
            .ToListAsync();
    }

    public async Task AddAsync(Alert alert)
    {
        await _context.Alerts.AddAsync(alert);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Alert alert)
    {
        _context.Alerts.Remove(alert);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Alert alert)
    {
        _context.Alerts.Update(alert);
        await _context.SaveChangesAsync();
    }
}