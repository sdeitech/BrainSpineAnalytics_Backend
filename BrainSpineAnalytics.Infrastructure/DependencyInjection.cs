using BrainSpineAnalytics.Application.Interfaces.Repositories.Auth;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Appointments;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Revenue;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Users;
using BrainSpineAnalytics.Application.Interfaces.Services.Auth;
using BrainSpineAnalytics.Application.Interfaces.Services.Appointments;
using BrainSpineAnalytics.Application.Interfaces.Services.Dashboard;
using BrainSpineAnalytics.Application.Interfaces.Services.Revenue;
using BrainSpineAnalytics.Application.Interfaces.Services.Users;
using BrainSpineAnalytics.Infrastructure.Data;
using BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Auth;
using BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Appointment;
using BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Revenue;
using BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Users;
using BrainSpineAnalytics.Infrastructure.Implementations.Services.Auth;
using BrainSpineAnalytics.Infrastructure.Implementations.Services.Appointment;
using BrainSpineAnalytics.Infrastructure.Implementations.Services.Dashboard;
using BrainSpineAnalytics.Infrastructure.Implementations.Services.Revenue;
using BrainSpineAnalytics.Infrastructure.Implementations.Services.Users;
using BrainSpineAnalytics.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BrainSpineAnalytics.Application.Interfaces.Repositories.ErrorHandling;
using BrainSpineAnalytics.Infrastructure.Implementations.Repositories.ErrorHandling;
using BrainSpineAnalytics.Application.Interfaces.Services.Menu;
using BrainSpineAnalytics.Infrastructure.Implementations.Services.Menu;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Menu;
using BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Menu;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Screen;
using BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Screen;
using BrainSpineAnalytics.Application.Interfaces.Services.Screen;
using BrainSpineAnalytics.Infrastructure.Implementations.Services.Screen;

namespace BrainSpineAnalytics.Infrastructure;

public static class DependencyInjection
{
 public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
 {
 services.AddDbContext<BrainSpineDbContext>(options =>
 options.UseNpgsql(configuration.GetConnectionString("BrainSpineDBConnection")));

 // Repositories
 services.AddScoped<IAuthRepo, AuthRepo>();
 services.AddScoped<IUserRepository, UserRepository>();
 services.AddScoped<IRevenueRepo, RevenueRepo>();
 services.AddScoped<IAppointmentRepo, AppointmentRepo>();
 services.AddScoped<ILogRepo, LogRepo>();
 services.AddScoped<IMenuRepo, MenuRepo>();
 services.AddScoped<IScreenRepo, ScreenRepo>();

        // Services
        services.AddScoped<IAuthenticationService, AuthenticationService>();
 services.AddScoped<IUserService, UserService>();
 services.AddScoped<IRevenueService, RevenueService>();
 services.AddScoped<IAppointmentService, AppointmentService>();
 services.AddScoped<IDashboardService, DashboardService>();
 services.AddScoped<IMenuService, MenuService>();
 services.AddScoped<IScreenService, ScreenService>();


 // Security
 services.AddSingleton<BrainSpineAnalytics.Application.Interfaces.Security.IPasswordHasher, Pbkdf2PasswordHasher>();

 return services;
 }
}
