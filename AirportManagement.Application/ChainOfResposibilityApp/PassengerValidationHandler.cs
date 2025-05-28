using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Core.ChainOfResponsibility;
using AirportManagement.Core.Models;

namespace AirportManagement.Application.ChainOfResposibilityApp;

public class PassengerValidationHandler : TicketValidationHandlerBase
{
    private readonly IPassengerRepository _passengerRepository;

    public PassengerValidationHandler(IPassengerRepository passengerRepository)
    {
        _passengerRepository = passengerRepository;
    }

    public override async Task HandleAsync(CreateTicketRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.FirstName) ||
            string.IsNullOrWhiteSpace(request.LastName) ||
            string.IsNullOrWhiteSpace(request.PassportNumber))
        {
            throw new Exception("Datele pasagerului sunt incomplete.");
        }

        var existing = await _passengerRepository.GetPassengerByPassportAsync(request.PassportNumber);
        if (existing != null)
        {
            
        }

        await base.HandleAsync(request);
    }
}