using Core.Data;
using Core.WebApi.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Livro.Data;
using ShopServices.Api.Livro.Data.ExecuteScript;
using ShopServices.RabbitMQ.Bus.BusRabbit;

namespace ShopServices.Api.Livro.Configurations
{
    public static class DependenciesInjection
    {
        public static void AddDependenciesInjection(this IServiceCollection services, IConfiguration configuration)
        {
            

            var conexao = configuration.GetConnectionString("ConexaoSqlServer");
            //services.AddDbContext<AutorContext>();
            services.AddDbContext<LivroContext>(options =>
            {
                options.UseSqlServer(conexao);
            });

            
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddSingleton<IRabbitEventBus, RabbitEventBus>(scope =>
            {
                var scopeFactory = scope.GetRequiredService<IServiceScopeFactory>();
                return new RabbitEventBus(scope.GetService<IMediator>(), scope.GetService<IRabbitMQConnection>(), scopeFactory);
            });

            services.AddTransient<IRabbitMQConnection>(provider=> new RabbitMQConnection(configuration.GetMessageQueueConnection("RabbitMqMessage")));
 
        }
    }
}
