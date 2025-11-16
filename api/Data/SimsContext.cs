using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class SimsContext : DbContext
    {
        public SimsContext(DbContextOptions<SimsContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<UserRole> UserRoles { get; set; } = null!;
        public DbSet<Alert> Alerts { get; set; } = null!;
        public DbSet<Incident> Incidents { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<Incident>()
                .HasOne(i => i.AssignedUser)
                .WithMany(u => u.AssignedIncidents)
                .HasForeignKey(i => i.AssignedUserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Incident>()
                .HasOne(i => i.Alert)
                .WithMany(a => a.Incidents)
                .HasForeignKey(i => i.AlertId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}