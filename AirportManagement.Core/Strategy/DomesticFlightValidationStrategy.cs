using AirportManagement.Core.Models;

namespace AirportManagement.Core.Strategy;

public class DomesticFlightValidationStrategy : IPassengerValidationStrategy
{
    public Task<bool> ValidatePassengerAsync(Passenger passenger, Flight flight)
    {
        return Task.FromResult(true);
    }
}