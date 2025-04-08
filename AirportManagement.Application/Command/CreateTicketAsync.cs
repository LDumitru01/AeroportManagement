using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Core.Enums;
using AirportManagement.Core.Models;

namespace AirportManagement.Application.Command;

public class CreateTicketCommand : ICommand
{
    private readonly ITicketService _ticketService;
    private Ticket? _createdTicket;
    private readonly int _flightId;
    private readonly string _firstName;
    private readonly string _lastName;
    private readonly string _passportNumber;
    private readonly MealType _mealOption;
    private readonly SeatType _seat;
    private readonly double? _luggageWeight;

    public CreateTicketCommand(
        ITicketService ticketService,
        int flightId,
        string firstName,
        string lastName,
        string passportNumber,
        MealType mealOption,
        SeatType seat,
        double? luggageWeight = null)
    {
        _ticketService = ticketService;
        _flightId = flightId;
        _firstName = firstName;
        _lastName = lastName;
        _passportNumber = passportNumber;
        _mealOption = mealOption;
        _seat = seat;
        _luggageWeight = luggageWeight;
    }

    public async Task ExecuteAsync()
    {
        _createdTicket = await _ticketService.CreateTicketAsync(
            _flightId, _firstName, _lastName, _passportNumber, _mealOption, _seat, _luggageWeight);
    }

    public async Task UndoAsync()
    {
        if (_createdTicket != null)
        {
            await _ticketService.DeleteTicketAsync(_createdTicket.Id);
        }
    }
}
