using Kup1Gis.Domain.Extensions;
using Kup1Gis.Infrastructure.Extensions;
using Microsoft.AspNetCore.HttpLogging;

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
        services.AddHttpLogging(logging =>
        {
            logging.LoggingFields = HttpLoggingFields.RequestPath | HttpLoggingFields.RequestBody | HttpLoggingFields.ResponseBody;
            logging.RequestHeaders.Add("sec-ch-ua");
            logging.ResponseHeaders.Add("MyResponseHeader");
            logging.MediaTypeOptions.AddText("application/javascript");
            logging.RequestBodyLogLimit = 4096;
            logging.ResponseBodyLogLimit = 4096;
            logging.CombineLogs = true;
        });
        services.AddControllersWithViews();

        return services;
    }
}