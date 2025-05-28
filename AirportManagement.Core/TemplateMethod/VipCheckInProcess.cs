namespace AirportManagement.Core.TemplateMethod;

public class VipCheckInProcess : CheckInProcess
{
    protected override void VerifyTicket()
    {
        Console.WriteLine("VIP: Ticket verified with priority.");
    }

    protected override void VerifyPassport()
    {
        Console.WriteLine("VIP: Passport verified with assistance.");
    }

    protected override void DropLuggage()
    {
        Console.WriteLine("VIP: Luggage picked up by personal assistant.");
    }

    protected override void PrintBoardingPass()
    {
        Console.WriteLine("VIP: Boarding pass delivered personally.");
    }
}