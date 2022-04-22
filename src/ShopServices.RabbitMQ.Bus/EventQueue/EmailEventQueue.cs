using ShopServices.RabbitMQ.Bus.Events;

namespace ShopServices.RabbitMQ.Bus.EventQueue;

public class EmailEventQueue : Event
{
    public EmailEventQueue(string destinatario, string titulo, string conteudo)
    {
        Destinatario = destinatario;
        Titulo = titulo;
        Conteudo = conteudo;
    }

    public string Destinatario { get; set; }
    public string Titulo { get; set; }
    public string Conteudo { get; set; }


}
