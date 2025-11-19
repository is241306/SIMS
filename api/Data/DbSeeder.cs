using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public static class DbSeeder
    {
        public static void Seed(SimsContext db)
        {
            
            if (!db.Roles.Any())
            {
                db.Roles.AddRange(
                    new Role { Name = "Admin" },
                    new Role { Name = "Analyst" }
                );
            }

            
            if (!db.Users.Any())
            {
                db.Users.Add(new User
                {
                    Username = "admin",
                    PasswordHash = "placeholder",
                    IsActive = true
                });
            }

            db.SaveChanges();
        }
    }
}