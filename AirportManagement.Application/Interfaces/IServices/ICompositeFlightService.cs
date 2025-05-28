using AirportManagement.Core.CompositePattern;

namespace AirportManagement.Application.Interfaces.IServices;

public interface ICompositeFlightService
{
    Task<IFlightComponent> BuildCompositeFlightAsync(List<string> flightNumbers);
}