using ShopServices.RabbitMQ.Bus.Messages;

namespace ShopServices.RabbitMQ.Bus.Commands;

public abstract class Command : Message
{
    public DateTime Timespam { get; protected set; }

    public Command()
    {
        Timespam = DateTime.Now;    
    }
}
