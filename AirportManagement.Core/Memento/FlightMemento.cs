using AirportManagement.Core.Enums;

namespace AirportManagement.Core.Memento;

public class FlightMemento
{
    public FlightMemento(FlightStatus status, DateTime departureTime, string flightNumber, string destination, int id)
    {
        Status = status;
        DepartureTime = departureTime;
        FlightNumber = flightNumber;
        Destination = destination;
        Id = id;
    }

    public int Id { get;}
    public string FlightNumber { get; }
    public string Destination { get; }
    public DateTime DepartureTime { get; }
    public FlightStatus Status { get; }
    
}