namespace AirportManagement.Core.CompositePattern;

public class CompositeFlight : IFlightComponent
{
    private readonly List<IFlightComponent> _flights = new();

    public void Add(IFlightComponent flightComponent)
    {
        _flights.Add(flightComponent);
    }

    public void Remove(IFlightComponent flightComponent)
    {
        _flights.Remove(flightComponent);
    }

    public string GetFlightDetails()
    {
        if (!_flights.Any())
            return "No flights in this composite.";

        return string.Join("\n", _flights.Select(f => f.GetFlightDetails()));
    }

    public decimal GetPrice()
    {
        return _flights.Sum(f => f.GetPrice());
    }
}