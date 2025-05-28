namespace AirportManagement.Core.TemplateMethod;

public class BusinessCheckInProcess : CheckInProcess
{
    protected override void VerifyTicket()
    {
        Console.WriteLine("Business: Ticket verified.");
    }

    protected override void VerifyPassport()
    {
        Console.WriteLine("Business: Passport verified.");
    }

    protected override void DropLuggage()
    {
        Console.WriteLine("Business: Luggage dropped at business counter.");
    }

    protected override void PrintBoardingPass()
    {
        Console.WriteLine("Business: Boarding pass printed.");
    }
}