using Kup1Gis.Domain.Extensions;
using Kup1Gis.Infrastructure.Extensions;

namespace Kup1Gis.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        string connectionString)
    {
        services.AddAppDbContext(connectionString);
        services.AddRepositories();

        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddModelServices();
        services.AddDirectorySystem();

        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddControllersWithViews();

        return services;
    }
}