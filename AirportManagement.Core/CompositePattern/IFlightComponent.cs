namespace AirportManagement.Core.CompositePattern;

public interface IFlightComponent
{
    string GetFlightDetails();
    decimal GetPrice();
}