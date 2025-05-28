using AirportManagement.Core.Models;

namespace AirportManagement.Core.Visitor;

public class FlightStatisticsVisitor : IVisitor
{
    public int TicketCount { get; private set; }
    public int PassengerCount { get; private set; }
    public int InternationalFlightCount { get; private set; }
    
    public void VisitTicket(Ticket ticket)
    {
        TicketCount++;
    }

    public void VisitPassenger(Passenger passenger)
    {
        PassengerCount++;
    }

    public void VisitFlight(Flight flight)
    {
        if (flight.IsInternational)
            InternationalFlightCount++;
    }
}