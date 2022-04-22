using SendGrid;
using SendGrid.Helpers.Mail;
using ShopServices.Message.Email.SendGrid.Interfaces;
using ShopServices.Message.Email.SendGrid.Models;

namespace ShopServices.Message.Email.SendGrid.Implements;

public class SendGridEmail : ISendGridEmail
{
    public async Task<(bool result, string errorMessage)> SendEmail(SendGridData data)
    {
        try
        {
            var email = "remetente@teste.com";
            var titulo = "Integração entre Microservices";

            var sendGridClient = new SendGridClient(data.SendGridAPIKey);
            var destinario = new EmailAddress(data.EmailDestinario, data.NomeDestinatario);
            var tituloEmail = data.Titulo;
            var enviar = new EmailAddress(email, titulo);
            var conteudo = data.Conteudo;

            var message = MailHelper.CreateSingleEmail(enviar, destinario, tituloEmail, conteudo, conteudo);
            await sendGridClient.SendEmailAsync(message);

            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}
