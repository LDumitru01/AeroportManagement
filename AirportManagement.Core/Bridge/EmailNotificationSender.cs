using System.Net;
using System.Net.Mail;

namespace AirportManagement.Core.Bridge;

public class EmailNotificationSender : INotificationSender
{
    public async Task SendAsync(string destination, string message)
    {
        using var client = new SmtpClient("smtp.gmail.com", 587);
        client.EnableSsl = true;
        client.Credentials = new NetworkCredential("d2leahu2003@gmail.com", "bcgimsyzpwsunayf");

        var mail = new MailMessage("youremail@gmail.com", destination)
        {
            Subject = "Notificare Zbor",
            Body = message
        };

        await client.SendMailAsync(mail);
    }
}