using sims.Models;

namespace sims.Data;
using Microsoft.EntityFrameworkCore;
using sims.Models;

public class SimsContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Incident> Incidents { get; set; }
    public DbSet<Alerts> Alerts { get; set; }
    public SimsContext(DbContextOptions<SimsContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}