using AirportManagement.Core.Models;

namespace AirportManagement.Core.CompositePattern;

public class FlightLeaf : IFlightComponent
{
    private readonly Flight _flight;

    public FlightLeaf(Flight flight)
    {
        _flight = flight;
    }

    public string GetFlightDetails()
    {
        return $"Flight {_flight.FlightNumber} from {_flight.DepartureTime} to {_flight.Destination} ({_flight.Price}$)";
    }

    public decimal GetPrice()
    {
        return 0;
    }
}