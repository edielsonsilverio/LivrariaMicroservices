using Core.Data;
using Core.WebApi.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Autor.Applications;
using ShopServices.Api.Autor.Applications.Event;
using ShopServices.Api.Autor.Data;
using ShopServices.Api.Autor.Data.ExecuteScript;
using ShopServices.Message.Email.SendGrid.Implements;
using ShopServices.Message.Email.SendGrid.Interfaces;
using ShopServices.RabbitMQ.Bus.BusRabbit;
using ShopServices.RabbitMQ.Bus.EventQueue;

namespace ShopServices.Api.Autor.Configurations
{
    public static class DependenciesInjection
    {
        public static void AddDependenciesInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRabbitMQConnection>(provider => new RabbitMQConnection(configuration.GetMessageQueueConnection("RabbitMqMessage")));
            
            services.AddSingleton<IRabbitEventBus, RabbitEventBus>(scope =>
            {
                var scopeFactory = scope.GetRequiredService<IServiceScopeFactory>();
                return new RabbitEventBus(scope.GetService<IMediator>(),scope.GetService<IRabbitMQConnection>(), scopeFactory);
            });

            services.AddSingleton<ISendGridEmail, SendGridEmail>();

            services.AddTransient<EmailEventHandler>();
            services.AddTransient<IEventHandler<EmailEventQueue>, EmailEventHandler>();

            var conexao = configuration.GetConnectionString("ConexaoPostgres");
            //services.AddDbContext<AutorContext>();
            services.AddDbContext<AutorContext>(options =>
            {
                options.UseNpgsql(conexao);
            });


            services.AddTransient<IRabbitMQConnection>(provider => new RabbitMQConnection(configuration.GetMessageQueueConnection("RabbitMqMessage")));
            services.AddMediatR(typeof(NovoAutorCommand).Assembly);
            services.AddScoped<IDbInitializer, DbInitializer>();
        }
    }
}
