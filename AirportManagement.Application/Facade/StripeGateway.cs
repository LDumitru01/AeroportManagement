using AirportManagement.Application.Services.PaymentAdapters;

namespace AirportManagement.Application.Facade;

public class StripeGateway : IPaymentGateway
{
    public bool ProcessPayment(double amount, string currency)
    {
        Console.WriteLine($"[Stripe] Process payment of {amount} {currency}");
        return true;
    }
}