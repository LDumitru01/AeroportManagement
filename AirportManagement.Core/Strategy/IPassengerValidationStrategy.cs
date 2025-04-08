using AirportManagement.Core.Models;

namespace AirportManagement.Core.Strategy;

public interface IPassengerValidationStrategy
{
    Task<bool> ValidatePassengerAsync(Passenger passenger, Flight flight);
}