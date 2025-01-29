using Kup1Gis.Infrastructure.Extensions;
using Kup1Gis.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Kup1Gis;

public class Startup
{
    private readonly IConfiguration _configuration;
    private const string KeyConnectionString = "DefaultConnection";

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        
        string connectionString = _configuration.GetConnectionString(KeyConnectionString)!;
        services.AddInfrastructureServices(connectionString);
    }
 
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        using (AppDbContext db = CreateDbContext([]))
        {
            db.Database.Migrate(); 
        }

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        
        if (env.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        
        app.UseStaticFiles();
 
        app.UseRouting();
 
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name:"default", 
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
    
    private static AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
 
        ConfigurationBuilder builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");
        IConfigurationRoot config = builder.Build();
 
        string connectionString = config.GetConnectionString(KeyConnectionString)!;
        optionsBuilder.UseSqlite(connectionString);
        return new AppDbContext(optionsBuilder.Options);
    }
}