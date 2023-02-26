using Microsoft.Extensions.DependencyInjection;

namespace BlazorPortals;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPortals(this IServiceCollection services) => services.AddScoped<PortalRegistration>();
}
