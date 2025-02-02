using Kup1Gis.Domain.RepoInterfaces;
using Kup1Gis.Infrastructure.Persistance;
using Kup1Gis.Infrastructure.Repositories;
using Kup1Gis.Infrastructure.Repositories.Implications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kup1Gis.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options
                .UseLazyLoadingProxies()
                .UseSqlite(connectionString);
        });
        
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IKupRepository, KupRepository>();
        services.AddSingleton<IObservationRepository, ObservationRepository>();
        services.AddSingleton<ICoordinatesRepository, CoordinatesRepository>();
        services.AddSingleton<IKupPropertyRepository, KupPropertyRepository>();
        services.AddSingleton<IPropertyRepository, PropertyRepository>();
        
        return services;
    }
}