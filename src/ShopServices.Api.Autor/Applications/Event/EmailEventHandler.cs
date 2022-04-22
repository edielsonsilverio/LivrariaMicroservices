using ShopServices.Message.Email.SendGrid.Interfaces;
using ShopServices.Message.Email.SendGrid.Models;
using ShopServices.RabbitMQ.Bus.BusRabbit;
using ShopServices.RabbitMQ.Bus.EventQueue;

namespace ShopServices.Api.Autor.Applications.Event;

public class EmailEventHandler : IEventHandler<EmailEventQueue>
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<EmailEventHandler> _logger;
    private readonly ISendGridEmail _senderGrid;

    public EmailEventHandler(
        ILogger<EmailEventHandler> logger,
        ISendGridEmail senderGrid,
        IConfiguration configuration)
    {
        _logger = logger;
        _senderGrid = senderGrid;
        _configuration = configuration;
    }

    public async Task Handle(EmailEventQueue @event)
    {
        _logger.LogInformation($"Mensagem Título: {@event.Titulo}");

        var email = new SendGridData
        {
            Conteudo = @event.Conteudo,
            EmailDestinario = @event.Destinatario,
            NomeDestinatario = @event.Destinatario,
            Titulo = @event.Titulo,
            SendGridAPIKey = _configuration["SendGrid:ApiKey"]
        };

        //Envia o Email
        var result = await _senderGrid.SendEmail(email);

        //Verifica se o email foi enviado com sucesso
        if (result.result)
            await Task.CompletedTask;

        return;
    }
}
