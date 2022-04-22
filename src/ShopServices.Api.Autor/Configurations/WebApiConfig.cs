using Core.Data;
using FluentValidation.AspNetCore;
using ShopServices.Api.Autor.Applications.Event;
using ShopServices.RabbitMQ.Bus.BusRabbit;
using ShopServices.RabbitMQ.Bus.EventQueue;

namespace ShopServices.Api.Autor.Configurations;

public static class WebApiConfig
{
    public static void AddWebApiConfig(this IServiceCollection services)
    {
        services.AddControllers()
           .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Startup>());

        services.AddAutoMapper(typeof(Startup).Assembly);

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

        app.UseAuthorization();

        app.MapControllers();

        IniciarDatabase(app);

        var eventBus = app.Services.GetRequiredService<IRabbitEventBus>();
        eventBus.Subscribe<EmailEventQueue, EmailEventHandler>();

    }

    private static void IniciarDatabase(WebApplication app)
    {
        using (var serviceScope = app.Services.CreateScope())
        {
            var services = serviceScope.ServiceProvider;

            var initial = services.GetRequiredService<IDbInitializer>();
            initial.Initialize();
        }
    }
}
