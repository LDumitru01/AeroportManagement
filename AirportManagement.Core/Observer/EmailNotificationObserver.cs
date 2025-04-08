namespace AirportManagement.Core.Observer;

public class EmailNotificationObserver : IObserver
{
    public void Update(string flightNumber, string status)
    {
        Console.WriteLine($"[EMAIL] Flight {flightNumber} changed status to: {status}");
    }
}