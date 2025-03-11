namespace AirportManagement.Core.CompositePatttern;

public class TicketPackage : ITicketComponent
{
    private readonly List<ITicketComponent> _tickets = new();

    public void AddTicket(ITicketComponent ticket)
    {
        _tickets.Add(ticket);
    }

    public decimal GetPrice()
    {
        return _tickets.Sum(ticket => ticket.GetPrice());
    }

    public string GetTicketInfo()
    {
        return $"Ticket Package - Total Price: {GetPrice()}$ | Includes: " +
               string.Join("; ", _tickets.Select(t => t.GetTicketInfo()));
    }
}