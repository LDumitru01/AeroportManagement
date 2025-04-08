using AirportManagement.Application.Services.PaymentAdapters;

namespace AirportManagement.Application.Facade;

public class PayPalGateway : IPaymentGateway
{
    public bool ProcessPayment(double amount, string currency)
    {
        Console.WriteLine($"[PayPal] Process payment of {amount} {currency}");
        return true;
    }
}
