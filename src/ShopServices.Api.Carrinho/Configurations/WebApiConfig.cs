using Core.Data;
using FluentValidation.AspNetCore;
using ShopServices.Api.Carrinho;

namespace ShopServices.Api.Livro.Configurations
{
    public static class WebApiConfig
    {
        public static void AddWebApiConfig(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddControllers()
               .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHttpClient("ApiLivros", config =>
            {
                config.BaseAddress = new Uri(configuration["Services:ApiLivros"]);
            });
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
}
