using api.Data;
using api.Repositories;
using api.Services;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Threading.Tasks;



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

        // ------------------------------
        // API setup
        // ------------------------------
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        // Redis 
        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = builder.Configuration["Redis:Connection"];
        });
        
        
        var redis = ConnectionMultiplexer.Connect(builder.Configuration["Redis:Connection"]);
        builder.Services.AddSingleton<IConnectionMultiplexer>(redis);

        // Register the interface with the concrete service
        builder.Services.AddSingleton<IRedisLogService, RedisLogService>();

        
        
        var app = builder.Build();
        
        using (var scope = app.Services.CreateScope())
        {
            var redisLogService = scope.ServiceProvider.GetRequiredService<IRedisLogService>();

            // Check if there are already logs
            var existingLogs = await redisLogService.GetLatestLogsAsync(1);
            if (existingLogs.Length == 0)
            {
                // Add initial log entry
                await redisLogService.LogAsync("INFO", "Initial log entry", new { CreatedAt = DateTime.UtcNow });
            }
        }

        // ------------------------------
        //  MIGRATION 
        // ------------------------------
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<SimsContext>();
            db.Database.Migrate(); 
            DbSeeder.Seed(db);

        }

        // ------------------------------
        // Middleware
        // ------------------------------
        if (app.Environment.IsDevelopment()) {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();
        app.Run();
    }
}
