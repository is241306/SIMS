using api.Models;

namespace api.Data;
using Microsoft.EntityFrameworkCore;
using api.Models;

public class SimsContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<IncidentModel> Incidents { get; set; }

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