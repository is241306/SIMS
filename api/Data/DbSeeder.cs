using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

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
                db.SaveChanges();
            }

            // Testbenutzer erstellen
            if (!db.Users.Any())
            {
                var users = new[]
                {
                    CreateUser("admin", "admin123"),
                    CreateUser("user", "user123"),
                    CreateUser("testuser", "test123")
                };

                db.Users.AddRange(users);
                db.SaveChanges();
            }

            if (!db.Incidents.Any())
            {
                var incidents = new[]
                {
                    new Incident
                    {
                        Description = "Data breach attempt on customer database",
                        Severity = IncidentSeverity.Critical,
                        Status = IncidentStatus.Open,
                        CreatedAt = DateTime.UtcNow.AddHours(-8)
                    },
                    new Incident
                    {
                        Description = "DDoS attack targeting web services",
                        Severity = IncidentSeverity.Critical,
                        Status = IncidentStatus.InProgress,
                        CreatedAt = DateTime.UtcNow.AddHours(-6)
                    },
                    new Incident
                    {
                        Description = "Malicious insider activity detected",
                        Severity = IncidentSeverity.High,
                        Status = IncidentStatus.Escalated,
                        CreatedAt = DateTime.UtcNow.AddHours(-4)
                    },
                    new Incident
                    {
                        Description = "Unauthorized access to admin panel",
                        Severity = IncidentSeverity.High,
                        Status = IncidentStatus.Open,
                        CreatedAt = DateTime.UtcNow.AddHours(-3)
                    },
                    new Incident
                    {
                        Description = "Suspicious file encryption activity",
                        Severity = IncidentSeverity.Medium,
                        Status = IncidentStatus.InProgress,
                        CreatedAt = DateTime.UtcNow.AddHours(-2)
                    },
                    new Incident
                    {
                        Description = "Network anomaly in production environment",
                        Severity = IncidentSeverity.Medium,
                        Status = IncidentStatus.Open,
                        CreatedAt = DateTime.UtcNow.AddHours(-1)
                    },
                    new Incident
                    {
                        Description = "Outdated security patches on critical servers",
                        Severity = IncidentSeverity.Low,
                        Status = IncidentStatus.Resolved,
                        CreatedAt = DateTime.UtcNow.AddDays(-1)
                    }
                };
                
                db.Incidents.AddRange(incidents);
                db.SaveChanges();
            }

            if (!db.Alerts.Any())
            {
                var alerts = new[]
                {
                    new Alert
                    {
                        AlertExternalId = "AL-2024-001",
                        Description = "Ransomware encryption detected on file server",
                        AlertLevel = 4,
                        Host = "file-server-03",
                        Status = "New",
                        Timestamp = DateTime.UtcNow.AddMinutes(-10)
                    },
                    new Alert
                    {
                        AlertExternalId = "AL-2024-002",
                        Description = "Unauthorized API access from foreign IP",
                        AlertLevel = 4,
                        Host = "api-gateway-01",
                        Status = "New",
                        Timestamp = DateTime.UtcNow.AddMinutes(-25)
                    },
                    new Alert
                    {
                        AlertExternalId = "AL-2024-003",
                        Description = "Privilege escalation attempt detected",
                        AlertLevel = 3,
                        Host = "app-server-02",
                        Status = "Open",
                        Timestamp = DateTime.UtcNow.AddMinutes(-40)
                    },
                    new Alert
                    {
                        AlertExternalId = "AL-2024-004",
                        Description = "Suspicious outbound traffic to unknown domain",
                        AlertLevel = 3,
                        Host = "workstation-42",
                        Status = "Open",
                        Timestamp = DateTime.UtcNow.AddHours(-1)
                    },
                    new Alert
                    {
                        AlertExternalId = "AL-2024-005",
                        Description = "Multiple failed login attempts on admin account",
                        AlertLevel = 2,
                        Host = "web-portal",
                        Status = "InProgress",
                        Timestamp = DateTime.UtcNow.AddHours(-2)
                    },
                    new Alert
                    {
                        AlertExternalId = "AL-2024-006",
                        Description = "Unusual database query patterns detected",
                        AlertLevel = 2,
                        Host = "db-server-01",
                        Status = "Open",
                        Timestamp = DateTime.UtcNow.AddHours(-3)
                    },
                    new Alert
                    {
                        AlertExternalId = "AL-2024-007",
                        Description = "Firewall rule violation detected",
                        AlertLevel = 1,
                        Host = "firewall-02",
                        Status = "New",
                        Timestamp = DateTime.UtcNow.AddHours(-4)
                    }
                };
                
                db.Alerts.AddRange(alerts);
                db.SaveChanges();
            }

            Console.WriteLine("Database seeded successfully with sample data");
        }

        private static User CreateUser(string username, string password)
        {
            var salt = RandomNumberGenerator.GetBytes(16);
            var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32
            ));

            return new User
            {
                Username = username,
                PasswordHash = hash,
                PasswordSalt = Convert.ToBase64String(salt),
                IsActive = true
            };
        }
    }
}