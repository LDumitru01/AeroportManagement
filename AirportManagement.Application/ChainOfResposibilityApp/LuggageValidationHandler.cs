using AirportManagement.Core.ChainOfResponsibility;
using AirportManagement.Core.Models;

namespace AirportManagement.Application.ChainOfResposibilityApp;

public class LuggageValidationHandler : TicketValidationHandlerBase
{
    public override async Task HandleAsync(CreateTicketRequest request)
    {
        if (request.LuggageWeight.HasValue && request.LuggageWeight.Value > 30)
        {
            throw new Exception("Greutatea bagajului depaseste limita de 30kg.");
        }
        await base.HandleAsync(request);
    }
}