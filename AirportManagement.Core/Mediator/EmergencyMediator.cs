namespace AirportManagement.Core.Mediator;

public class EmergencyMediator : IMediator
{
    private readonly List<IEmergencyParticipant> _participants = new();
    public void RegisterParticipant(IEmergencyParticipant participant)
    {
        _participants.Add(participant);
    }

    public void NotifyParticipants(string emergencyMessage)
    {
        foreach (var participant in _participants)
        {
            participant.ReceiveEmergencyAlert(emergencyMessage);
        }
    }
}