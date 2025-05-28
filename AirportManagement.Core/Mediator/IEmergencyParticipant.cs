namespace AirportManagement.Core.Mediator;

public interface IEmergencyParticipant
{
    void ReceiveEmergencyAlert(string message);
}