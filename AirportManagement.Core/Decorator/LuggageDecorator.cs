namespace AirportManagement.Core.Decorator;

public class LuggageDecorator : TicketDecorator
{
    public double ExtraBags { get; set; }

    public LuggageDecorator(ITicketComponent ticket, double extraBags = 1) 
        : base(ticket)
    {
        ExtraBags = extraBags;
    }

    public override string GetTicketInfo()
    {
        return base.GetTicketInfo() + $", Extra Bags: {ExtraBags}";
    }
}