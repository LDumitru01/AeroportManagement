using AirportManagement.Core.Enums;

namespace AirportManagement.Core.Memento;

public class FlightMemento
{
    public FlightMemento(FlightStatus status, DateTime departureTime, string flightNumber, string destination, string number)
    {
        Status = status;
        DepartureTime = departureTime;
        FlightNumber = flightNumber;
        Destination = destination;
        Number = number;
    }

    public string Number { get;}
    public string FlightNumber { get; }
    public string Destination { get; }
    public DateTime DepartureTime { get; }
    public FlightStatus Status { get; }
    
}