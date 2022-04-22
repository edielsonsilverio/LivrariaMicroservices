using ShopServices.Message.Email.SendGrid.Models;

namespace ShopServices.Message.Email.SendGrid.Interfaces;

public interface ISendGridEmail
{
    Task<(bool result, string errorMessage)> SendEmail(SendGridData data);
}
