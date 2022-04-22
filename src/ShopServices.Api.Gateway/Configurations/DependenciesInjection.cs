using Core.WebApi;
using ShopServices.Api.Gateway.Services;

namespace ShopServices.Api.Gateway.Configurations;

public static class DependenciesInjection
{
    public static void AddDependenciesInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient("AutorService", config =>
         {
             config.BaseAddress = new Uri(configuration["Services:ApiAutores"]);
         });

        services.AddSingleton<IAutorService,AutorService>();
    }
}
