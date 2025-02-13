using Kup1Gis.Domain.RepoInterfaces;
using Kup1Gis.Infrastructure.Persistence;
using Kup1Gis.Infrastructure.Repositories;
using Kup1Gis.Infrastructure.Repositories.Implications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
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
                .UseSqlite(connectionString, b => b.MigrationsAssembly("Kup1Gis.Infrastructure"));
        });
        
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IKupRepository, KupRepository>();
        services.AddScoped<IObservationRepository, ObservationRepository>();
        services.AddScoped<ICoordinatesRepository, CoordinatesRepository>();
        services.AddScoped<IKupPropertyRepository, KupPropertyRepository>();
        services.AddScoped<IPropertyRepository, PropertyRepository>();
        
        return services;
    }
}