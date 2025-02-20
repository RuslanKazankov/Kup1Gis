using Kup1Gis.Extensions;
using Kup1Gis.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kup1Gis;

public class Startup
{
    private const string KeyConnectionString = "DefaultConnection";
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplicationServices();
        services.AddDomainServices();
        services.AddInfrastructureServices(_configuration.GetConnectionString(KeyConnectionString)!);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.Migrate();
        }

        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        if (env.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        var supportedCultures = new[] { "en-US" };
        var localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture(supportedCultures[0])
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);

        app.UseRequestLocalization(localizationOptions);

        app.UseStaticFiles();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                "default",
                "{controller=Home}/{action=Index}/{id?}");
        });
    }
}