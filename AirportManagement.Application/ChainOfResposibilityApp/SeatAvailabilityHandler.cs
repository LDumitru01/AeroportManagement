using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Core.ChainOfResponsibility;
using AirportManagement.Core.Enums;
using AirportManagement.Core.Models;

namespace AirportManagement.Application.ChainOfResposibilityApp;

public class SeatAvailabilityHandler : TicketValidationHandlerBase
{
    private readonly IFlightRepository _flightRepository;

    public SeatAvailabilityHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public override async Task HandleAsync(CreateTicketRequest request)
    {
        var flight = await _flightRepository.GetFlightByNumberAsync(request.FlightNumber);
        if (flight == null || flight.Status == FlightStatus.Cancelled)
        {
            throw new Exception("Zbor invalid sau anulat.");
        }
        if (request.Seat < 0)
        {   
            throw new Exception("Loc invalid.");
        }

        await base.HandleAsync(request); 
    }
}
