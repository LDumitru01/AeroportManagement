namespace AirportManagement.Core.TemplateMethod;

public abstract class CheckInProcess
{
    public void CheckIn()
    {
        VerifyTicket();
        VerifyPassport();
        DropLuggage();
        PrintBoardingPass();
    }
    
    protected abstract void VerifyTicket();
    protected abstract void VerifyPassport();
    protected abstract void DropLuggage();
    protected abstract void PrintBoardingPass();
    
}