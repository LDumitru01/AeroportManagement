namespace AirportManagement.Application.Services.PaymentAdapters;

public class PayPalAdapters: IPaymentGateway
{
    public bool ProcessPayment(double amount, string currency)
    {
        
        Console.WriteLine($"Processing payment via PayPal: {amount} {currency}");
        return true;
    }
}