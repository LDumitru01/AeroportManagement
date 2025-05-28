using AirportManagement.Core.Models;

namespace AirportManagement.Core.State;

public interface IPassengerState
{
    void CheckIn(PassengerContext context);
    void Board(PassengerContext context);
    string GetStatus();
}