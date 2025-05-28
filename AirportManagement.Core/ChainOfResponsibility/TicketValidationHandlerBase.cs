using AirportManagement.Core.Models;

namespace AirportManagement.Core.ChainOfResponsibility;

public abstract class TicketValidationHandlerBase : ITicketValidationHandler
{
    private ITicketValidationHandler? _next;

    protected TicketValidationHandlerBase() { }

    public virtual async Task HandleAsync(CreateTicketRequest request)
    {
        if (_next != null)
        {
            await _next.HandleAsync(request);
        }
    }

    public void SetNext(ITicketValidationHandler next)
    {
        _next = next;
    }
}