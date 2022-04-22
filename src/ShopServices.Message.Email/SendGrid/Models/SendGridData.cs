namespace ShopServices.Message.Email.SendGrid.Models;

public class SendGridData
{
    public string SendGridAPIKey { get; set; }
    public string EmailDestinario { get; set; }
    public string NomeDestinatario { get; set; }
    public string Titulo { get; set; }
    public string Conteudo { get; set; }

}
