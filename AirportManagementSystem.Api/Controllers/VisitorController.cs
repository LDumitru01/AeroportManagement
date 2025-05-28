using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Core.Visitor;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagementSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitorController : ControllerBase
{
    private readonly IFlightRepository _flightRepository;
    private readonly IPassengerRepository _passengerRepository;
    private readonly ITicketRepository _ticketRepository;

    public VisitorController(IFlightRepository flightRepository, IPassengerRepository passengerRepository, ITicketRepository ticketRepository)
    {
        _flightRepository = flightRepository;
        _passengerRepository = passengerRepository;
        _ticketRepository = ticketRepository;
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStatistics()
    {
        var visitor = new FlightStatisticsVisitor();

        var flights = await _flightRepository.GetAllFlightsAsync();
        var passengers = await _passengerRepository.GetAllPassengersAsync();
        var tickets = await _ticketRepository.GetAllTicketsAsync();

        foreach (var flight in flights)
            flight.Accept(visitor);

        foreach (var passenger in passengers)
            passenger?.Accept(visitor);

        foreach (var ticket in tickets)
            ticket.Accept(visitor);

        return Ok(new
        {
            visitor.TicketCount,
            visitor.PassengerCount,
            visitor.InternationalFlightCount
        });
    }
}