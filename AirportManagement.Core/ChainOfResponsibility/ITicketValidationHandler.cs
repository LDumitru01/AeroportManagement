using AirportManagement.Core.Models;

namespace AirportManagement.Core.ChainOfResponsibility;

public interface ITicketValidationHandler
{
    Task HandleAsync(CreateTicketRequest request);
    void SetNext(ITicketValidationHandler next);
}