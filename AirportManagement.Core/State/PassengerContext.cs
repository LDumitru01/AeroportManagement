namespace AirportManagement.Core.State;

public class PassengerContext
{
    private IPassengerState _state;

    public PassengerContext()
    {
        _state = new UnregisteredState();
    }

    public void SetState(IPassengerState newState)
    {
        _state = newState;
    }

    public void CheckIn()
    {
        _state.CheckIn(this);
    }

    public void Board()
    {
        _state.Board(this);
    }

    public string GetStatus()
    {
        return _state.GetStatus();
    }
}