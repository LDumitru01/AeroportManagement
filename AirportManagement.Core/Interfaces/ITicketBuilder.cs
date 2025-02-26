using AirportManagement.Core.Enums;
using AirportManagement.Core.Models;

namespace AirportManagement.Core.Interfaces;

public interface ITicketBuilder
{
    ITicketBuilder SetFlight(Flight flight);
    ITicketBuilder SetMealOption(MealType mealOption);
    ITicketBuilder SetSeat(SeatType seat);
    Ticket Build();
}