using ShopServices.Api.Gateway.Configurations;

namespace ShopServices.Api.Gateway;

public class Startup : Core.WebApi.IStartup
{
    public IConfiguration Configuration { get; }

    public Startup(IHostEnvironment hostEnvironment)
    {
        var ocelot = "ocelot.json";
        var builder = new ConfigurationBuilder()
            .SetBasePath(hostEnvironment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
            .AddJsonFile(ocelot)
            .AddEnvironmentVariables();

        //if (hostEnvironment.IsDevelopment())
        //    builder.AddUserSecrets<Startup>();

        Configuration = builder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddWebApiConfig(Configuration);

        services.AddDependenciesInjection(Configuration);
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        app.UseWebApiConfig(env);
    }
}
