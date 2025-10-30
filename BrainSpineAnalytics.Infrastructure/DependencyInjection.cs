using BrainSpineAnalytics.Application.Interfaces.Repositories;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Appointment;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Revenue;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Users;
using BrainSpineAnalytics.Application.Interfaces.Services;
using BrainSpineAnalytics.Application.Interfaces.Services.Appointment;
using BrainSpineAnalytics.Application.Interfaces.Services.Dashboard;
using BrainSpineAnalytics.Application.Interfaces.Services.Revenue;
using BrainSpineAnalytics.Application.Interfaces.Services.Users;
using BrainSpineAnalytics.Infrastructure.Data;
using BrainSpineAnalytics.Infrastructure.Implementations.Repositories;
using BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Appointment;
using BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Revenue;
using BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Users;
using BrainSpineAnalytics.Infrastructure.Implementations.Services;
using BrainSpineAnalytics.Infrastructure.Implementations.Services.Appointment;
using BrainSpineAnalytics.Infrastructure.Implementations.Services.Dashboard;
using BrainSpineAnalytics.Infrastructure.Implementations.Services.Revenue;
using BrainSpineAnalytics.Infrastructure.Implementations.Services.Users;
using BrainSpineAnalytics.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BrainSpineAnalytics.Infrastructure;

public static class DependencyInjection
{
 public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
 {
 services.AddDbContext<BrainSpineDBContext>(options =>
 options.UseNpgsql(configuration.GetConnectionString("BrainSpineDBConnection")));

 // Repositories
 services.AddScoped<IAuthRepo, AuthRepo>();
 services.AddScoped<IUserRepo, UserRepo>();
 services.AddScoped<IRevenueRepo, RevenueRepo>();
 services.AddScoped<IAppointmentRepo, AppointmentRepo>();

 // Services
 services.AddScoped<IAuthenticationService, AuthenticationService>();
 services.AddScoped<IUserService, UserService>();
 services.AddScoped<IRevenueService, RevenueService>();
 services.AddScoped<IAppointmentService, AppointmentService>();
 services.AddScoped<IDashboardService, DashboardService>();

 // Security
 services.AddSingleton<BrainSpineAnalytics.Application.Interfaces.Security.IPasswordHasher, Pbkdf2PasswordHasher>();

 return services;
 }
}
