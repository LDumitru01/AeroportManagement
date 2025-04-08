namespace AirportManagement.Application.Services.PaymentAdapters;

public class GooglePayAdapter : IPaymentGateway
{
    public bool ProcessPayment(double amount, string currency)
    {
        
        Console.WriteLine($"Processing payment via GooglePay: {amount} {currency}");
        return true;
    }
}