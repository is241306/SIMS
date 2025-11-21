using api.Data;
using api.Repositories;
using api.Services;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


public class Program {
    public static async Task Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        // ------------------------------
        // Database
        // ------------------------------
        builder.Services.AddDbContext<SimsContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // ------------------------------
        // Repository Interfaces
        // ------------------------------
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IAlertRepository, AlertRepository>();
        builder.Services.AddScoped<IIncidentRepository, IncidentRepository>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();

        // ------------------------------
        // Services
        // ------------------------------
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IAlertService, AlertService>();
        builder.Services.AddScoped<IIncidentService, IncidentService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<AuthService>();

        // ------------------------------
        // API setup
        // ------------------------------
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // ------------------------------
        // JWT Authentication
        // ------------------------------

        var jwtSection = builder.Configuration.GetSection("Jwt");
        var jwtKey = jwtSection["Key"];
        var jwtIssuer = jwtSection["Issuer"];
        var jwtAudience = jwtSection["Audience"];

        if (string.IsNullOrWhiteSpace(jwtKey))
            throw new InvalidOperationException("Jwt:Key is missing");

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

        builder.Services
            .AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtAudience,
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = !string.IsNullOrWhiteSpace(jwtIssuer),
                    ValidateAudience = !string.IsNullOrWhiteSpace(jwtAudience),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromDays(1)
                };
            });

        // ------------------------------
        // Redis 
        // ------------------------------
        var redisConnection = builder.Configuration["Redis:Connection"];

        if (string.IsNullOrWhiteSpace(redisConnection))
            throw new InvalidOperationException("Redis:Connection missing. Set Redis__Connection in docker-compose.");

        builder.Services.AddStackExchangeRedisCache(options => { options.Configuration = redisConnection; });

        builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
            ConnectionMultiplexer.Connect(redisConnection + ",abortConnect=false"));

        builder.Services.AddSingleton<IRedisLogService, RedisLogService>();


        var app = builder.Build();

        // ------------------------------
        // Apply EF Core Migrations & Seed Database
        // ------------------------------
        using (var scope = app.Services.CreateScope()){
            try{
                var db = scope.ServiceProvider.GetRequiredService<SimsContext>();
                db.Database.Migrate();
                
                // Seed database with sample data
                DbSeeder.Seed(db);
            }
            catch (Exception ex){
                Console.WriteLine($"Migration failed: {ex.Message}");
                throw;
            }
        }

        // ------------------------------
        // Seed Redis Log
        // ------------------------------
        using (var scope = app.Services.CreateScope()){
            try{
                var redisLog = scope.ServiceProvider.GetRequiredService<IRedisLogService>();
                var existing = await redisLog.GetLatestLogsAsync(1);

                if (existing.Length == 0)
                    await redisLog.LogAsync("INFO", "Initial log entry", new { CreatedAt = DateTime.UtcNow });
            }
            catch (Exception ex){
                Console.WriteLine($"Redis logging failed (likely Redis not ready yet): {ex.Message}");
            }
        }

        // ------------------------------
        // Middleware
        // ------------------------------
        if (app.Environment.IsDevelopment()){
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();

        app.MapControllers();
        app.Run();
    }
}