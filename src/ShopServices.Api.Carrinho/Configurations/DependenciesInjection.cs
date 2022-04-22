using Core.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Carrinho.Data;
using ShopServices.Api.Carrinho.Data.ExecuteScript;
using ShopServices.Api.Carrinho.Services;

namespace ShopServices.Api.Carrinho.Configurations
{
    public static class DependenciesInjection
    {
        public static void AddDependenciesInjection(this IServiceCollection services, IConfiguration configuration)
        {
            var conexao = configuration.GetConnectionString("ConexaoMySql");

            services.AddDbContext<CarrinhoContext>(options =>
            {
                //options.UseMySql(conexao,ServerVersion.Parse("5.7"));
                options.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
            });

            services.AddMediatR(typeof(Startup).Assembly);
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<ILivroService, LivroService>();
        }
    }
}
