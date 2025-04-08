namespace AirportManagement.Core.Bridge;

public class EmailNotificationSender : INotificationSender
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"Sending Email to: {to} : {message}" );
    }
}