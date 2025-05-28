namespace AirportManagement.Core.TemplateMethod;

public class EconomyCheckInProcess : CheckInProcess
{
    protected override void VerifyTicket()
    {
        Console.WriteLine("Economy Ticket verified");
    }

    protected override void VerifyPassport()
    {
        Console.WriteLine("Economy: Passport verified.");
    }

    protected override void DropLuggage()
    {
        Console.WriteLine("Economy: Luggage dropped at economy counter.");
    }
    
    protected override void PrintBoardingPass()
    {
        Console.WriteLine("Economy: Boarding pass printed.");
    }
}