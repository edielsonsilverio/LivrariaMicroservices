using Core.WebApi;
using ShopServices.Api.Autor;

var builder = WebApplication.CreateBuilder(args).UseStartup<Startup>();

//var builder = WebApplication.CreateBuilder(args);

//var startup = new Startup(builder.Environment);

//startup.ConfigureServices(builder.Services);

//var app = builder.Build();
//startup.Configure(app, app.Environment);

//using(var serviceScope = app.Services.CreateScope())
//{
//    var services = serviceScope.ServiceProvider;

//    var initial = services.GetRequiredService<IDbInitializer>();
//    initial.Initialize();
//}

//app.Run();



