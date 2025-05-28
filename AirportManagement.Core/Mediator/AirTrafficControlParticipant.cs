namespace AirportManagement.Core.Mediator;

public class AirTrafficControlParticipant : IEmergencyParticipant
{
    public string ControlTowerName { get; }

    public AirTrafficControlParticipant(string controlTowerName)
    {
        ControlTowerName = controlTowerName;
    }

    public void ReceiveEmergencyAlert(string message)
    {
        Console.WriteLine($"Turnul de control {ControlTowerName} a primit alerta de urgenta: {message}");
    }
}