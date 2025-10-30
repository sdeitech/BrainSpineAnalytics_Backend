using Microsoft.Extensions.DependencyInjection;

namespace BrainSpineAnalytics.Application;

public static class DependencyInjection
{
 public static IServiceCollection AddApplication(this IServiceCollection services)
 {
 // Register Application-layer services (validators, mappers, mediators) here when added.
 return services;
 }
}
