namespace AirportManagement.Core.State;

public class BoardedState : IPassengerState
{
    public void CheckIn(PassengerContext context)
    {
        throw new InvalidOperationException("Passenger already boarded. Cannot check-in.");
    }

    public void Board(PassengerContext context)
    {
        throw new InvalidOperationException("Passenger already boarded.");
    }

    public string GetStatus()
    {
        return "Boarded";
    }
}