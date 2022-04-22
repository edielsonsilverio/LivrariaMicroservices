using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ShopServices.RabbitMQ.Bus.Commands;
using ShopServices.RabbitMQ.Bus.Events;
using System.Text;

namespace ShopServices.RabbitMQ.Bus.BusRabbit;

public class RabbitEventBus : IRabbitEventBus
{

    private readonly IMediator _mediator;
    private readonly IRabbitMQConnection _connectionString;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    private readonly Dictionary<string, List<Type>> _handler;
    private readonly List<Type> _eventTypes;

    public RabbitEventBus(
        IMediator mediator, 
        IRabbitMQConnection connectionString, 
        IServiceScopeFactory serviceScopeFactory)
    {
        _mediator = mediator;
        _connectionString = connectionString;
        _serviceScopeFactory = serviceScopeFactory;
        _handler = new Dictionary<string, List<Type>>();
        _eventTypes = new List<Type>();
    }

    public Task SendCommand<T>(T command) where T : Command
    {
        return _mediator.Send(command);
    }

    public void Publish<T>(T eventMessage) where T : Event
    {
        var factory = new ConnectionFactory { HostName = ObterConnectionString() };

        using (var connection = factory.CreateConnection())  //Cria a conexão com o RabbitMq
        using (var channel = connection.CreateModel())       //Cria um canal de comunicação
        {
            var eventName = eventMessage.GetType().Name;

            channel.QueueDeclare(eventName, false, false, false, null);

            var message = JsonConvert.SerializeObject(eventMessage);
            var body = Encoding.UTF8.GetBytes(message);

            //Publica o evento
            channel.BasicPublish("", eventName, null, body);

        }
    }

    public void Subscribe<T, TH>()
        where T : Event
        where TH : IEventHandler<T>
    {
        var eventName = typeof(T).Name;
        var handlerEventType = typeof(TH);

        if (!_eventTypes.Contains(typeof(T)))
            _eventTypes.Add(typeof(T));


        if (!_handler.ContainsKey(eventName))
            _handler.Add(eventName, new List<Type>());

        if (_handler[eventName].Any(x => x.GetType() == handlerEventType))
            throw new ArgumentException($"O manipulador {handlerEventType.Name} já foi registrado anteriormente por {eventName}");

        _handler[eventName].Add(handlerEventType);

        //Cria uma instância de conexão RabbitMq
        var factory = new ConnectionFactory
        {
            HostName = ObterConnectionString(),
            DispatchConsumersAsync = true
        };

        //Criar uma conexão e abre para acesso
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(eventName, false, false, false, null);

        //Cria uma evento para consumir o fila
        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.Received += Consumer_Delegate;

        channel.BasicConsume(eventName, true, consumer);
    }

    private async Task Consumer_Delegate(object sender, BasicDeliverEventArgs e)
    {
        //Obtêm o nome do evento
        var eventName = e.RoutingKey;

        //Obtêm a mensagem.
        var message = Encoding.UTF8.GetString(e.Body.ToArray());

        try
        {
            if (_handler.ContainsKey(eventName))
            {
                using(var scope = _serviceScopeFactory.CreateScope())
                {
                    var subscriptions = _handler[eventName];
                    foreach (var subscription in subscriptions)
                    {
                        //Cria uma instância
                        var handler = scope.ServiceProvider.GetService(subscription);  //Activator.CreateInstance(subscription);
                        if (handler == null) continue;

                        var eventType = _eventTypes.SingleOrDefault(x => x.Name == eventName);
                        var eventDeserialize = JsonConvert.DeserializeObject(message, eventType);

                        //Chama a interface genérica.
                        var result = typeof(IEventHandler<>).MakeGenericType(eventType);

                        //Invoca o método através de Reflaction.
                        await (Task)result.GetMethod("Handle").Invoke(handler, new object[] { eventDeserialize });

                    }
                }
            }
        }
        catch (Exception ex)
        {
            var erro = ex.Message;
        }
    }

    private string ObterConnectionString()
    {
        return _connectionString.GetConnectionString();
        //return "localhost";
        //return "rabbitmq-shop";
    }
}
