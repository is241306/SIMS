using api.Data;
using api.Repositories;
using api.Services;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class Program {
    public static void Main(string[] args) {
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

        var app = builder.Build();

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
