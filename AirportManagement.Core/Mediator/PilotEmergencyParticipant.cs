namespace AirportManagement.Core.Mediator;

public class PilotEmergencyParticipant : IEmergencyParticipant
{
    public PilotEmergencyParticipant(string pilotName)
    {
        PilotName = pilotName;
    }

    public string PilotName { get; }
    
    public void ReceiveEmergencyAlert(string message)
    {
        Console.WriteLine($"Pilot {PilotName} a primit alerta de urgenta: {message}");
    }
}