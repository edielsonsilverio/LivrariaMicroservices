using Core.Data;
using FluentValidation.AspNetCore;

namespace ShopServices.Api.Livro.Configurations
{
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
