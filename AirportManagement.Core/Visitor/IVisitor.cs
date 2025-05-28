using AirportManagement.Core.Models;

namespace AirportManagement.Core.Visitor;

public interface IVisitor
{
    void VisitTicket(Ticket ticket);
    void VisitPassenger(Passenger passenger);
    void VisitFlight(Flight flight);
}