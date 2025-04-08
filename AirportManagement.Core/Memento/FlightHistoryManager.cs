using AirportManagement.Core.Models;

namespace AirportManagement.Core.Memento;

public class FlightHistoryManager
{
    private readonly Stack<FlightMemento> _history = new();

    public void SaveState(FlightStateManager flightManager)
    {
        _history.Push(flightManager.SaveState());
    }

    public FlightMemento? RestoreLastState()
    {
        return _history.Count > 0 ? _history.Pop() : null;
    }
}