using ShopServices.Api.Livro.Configurations;

namespace ShopServices.Api.Livro
{
    public class Startup : Core.WebApi.IStartup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            //if (hostEnvironment.IsDevelopment())
            //    builder.AddUserSecrets<Startup>();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebApiConfig();
            services.AddDependenciesInjection(Configuration);
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseWebApiConfig(env);
        }
    }
}
