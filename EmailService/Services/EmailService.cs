using System.Net;
using System.Net.Mail;

namespace EmailService.Services;

public class EmailService : IEmailService
{
    public Task<bool> CheckEmailService()
    {
        string to = "jane@contoso.com";
        string from = "ben@contoso.com";
        MailMessage message = new MailMessage(from, to);
        message.Subject = "Using the new SMTP client.";
        message.Body = @"Using this new feature, you can send an email message from an application very easily.";
        

        var client = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("username", "password"),
            EnableSsl = true,
        };

        client.UseDefaultCredentials = true;

        try
        {
            client.Send(message);
            return Task.FromResult(true);
        }
        catch
        {
             return Task.FromResult(false);
        }
       
    }
}