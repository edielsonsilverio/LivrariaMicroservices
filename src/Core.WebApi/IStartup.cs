

namespace Core.WebApi
{
    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void ConfigureServices(IServiceCollection services);
        void Configure(WebApplication app, IWebHostEnvironment env);
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webAppBuilder)
            where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), webAppBuilder.Environment) as IStartup;
            if (startup == null) throw new ArgumentException("Classe Startup.cs inválida!");

            startup.ConfigureServices(webAppBuilder.Services);

            var app = webAppBuilder.Build();
            startup.Configure(app, app.Environment);
            app.Run();

            return webAppBuilder;
        }
    }
}
