using Kup1Gis.Domain.Services;
using Kup1Gis.Domain.Services.Implications;
using Microsoft.Extensions.DependencyInjection;

namespace Kup1Gis.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddModelServices(this IServiceCollection services)
    {
        services.AddSingleton<IKupService, KupService>();
        return services;
    }
}