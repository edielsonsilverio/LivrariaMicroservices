using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using ShopServices.Api.Gateway.MessageHanlder;

namespace ShopServices.Api.Gateway.Configurations;

public static class WebApiConfig
{
    public static void AddWebApiConfig(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddControllers()
        //   .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Startup>());



        //services.AddAutoMapper(typeof(Startup).Assembly);
        services.AddOcelot(configuration)
            .AddDelegatingHandler<LivroHandler>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();


    }

    public static void UseWebApiConfig(this WebApplication app, IWebHostEnvironment env)
    {
        //if (env.IsDevelopment())
        //{
        app.UseSwagger();
        app.UseSwaggerUI();
        //}

        //app.UseAuthorization();

        app.MapControllers();

        app.UseOcelot().Wait();
    }
}
