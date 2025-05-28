namespace AirportManagement.Core.Mediator;

public interface IMediator
{
    void RegisterParticipant (IEmergencyParticipant  participant);
    void NotifyParticipants (string emergencyMessage);
}