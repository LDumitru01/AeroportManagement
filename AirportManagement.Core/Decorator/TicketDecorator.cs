namespace AirportManagement.Core.Decorator;

public abstract class TicketDecorator : ITicketComponent
{
    protected readonly ITicketComponent Ticket;

    protected TicketDecorator(ITicketComponent ticket)
    {
        Ticket = ticket;
    }

    public virtual string GetTicketInfo() => Ticket.GetTicketInfo();
}