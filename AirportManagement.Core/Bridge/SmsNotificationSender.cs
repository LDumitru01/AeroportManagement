namespace AirportManagement.Core.Bridge;

public class SmsNotificationSender : INotificationSender
{
    public Task SendAsync(string to, string message)
    {
        Console.WriteLine($"Sending message: {to}: {message}");
        return Task.CompletedTask;
    }
}