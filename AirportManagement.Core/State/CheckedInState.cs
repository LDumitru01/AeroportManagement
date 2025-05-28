namespace AirportManagement.Core.State;

public class CheckedInState : IPassengerState
{
    public void CheckIn(PassengerContext context)
    {
        throw new System.NotImplementedException("Passenger not allready checked in");
    }

    public void Board(PassengerContext context)
    {
        context.SetState(new BoardedState());
    }

    public string GetStatus()
    {
        return "Checked-In";
    }
}