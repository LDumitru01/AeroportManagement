namespace AirportManagement.Core.Observer;

public class SmsNotificationObserver : IObserver
{
    public void Update(string flightNumber, string status)
    {
        Console.WriteLine($"[SMS] Flight {flightNumber} changed status to: {status}");
    }
}