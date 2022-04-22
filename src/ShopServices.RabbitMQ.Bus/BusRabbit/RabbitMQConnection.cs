namespace ShopServices.RabbitMQ.Bus.BusRabbit;

public class RabbitMQConnection : IRabbitMQConnection
{
    private readonly string _connection;

    public RabbitMQConnection(string connection)
    {
        _connection = connection;
    }

    public string GetConnectionString()
    {
        return _connection;
    }
}

