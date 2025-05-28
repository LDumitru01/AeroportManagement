namespace AirportManagement.Core.State;

public class UnregisteredState : IPassengerState
{
    public void CheckIn(PassengerContext context)
    {
        context.SetState(new CheckedInState());
    }

    public void Board(PassengerContext context)
    {
        throw new NotImplementedException("Passenger mus check in before boarding");
    }

    public string GetStatus()
    {
        return "Unregistered";
    }
}