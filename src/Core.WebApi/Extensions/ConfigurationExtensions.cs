namespace Core.WebApi.Extensions;

public static class ConfigurationExtensions
{
    //Cria um método de extensão para pegar as informações do app.settings.
    public static string GetMessageQueueConnection(this IConfiguration configuration, string name)
    {
        return configuration?.GetSection("RabbitMQ")?[name];
    }
}
