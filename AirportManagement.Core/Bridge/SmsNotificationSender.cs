namespace AirportManagement.Core.Bridge;

public class SmsNotificationSender : INotificationSender
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"Sending message: {to}: {message}");   
    }
}