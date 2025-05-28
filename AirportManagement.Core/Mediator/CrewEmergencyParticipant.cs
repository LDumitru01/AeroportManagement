namespace AirportManagement.Core.Mediator;

public class CrewEmergencyParticipant : IEmergencyParticipant
{
    public string CrewName { get; }

    public CrewEmergencyParticipant(string crewName)
    {
        CrewName = crewName;
    }

    public void ReceiveEmergencyAlert(string message)
    {
        Console.WriteLine($"Echipajul {CrewName} a primit alerta de urgenta: {message}");
    }
}