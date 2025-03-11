namespace AirportManagement.Application.Services.PaymentAdapters;

public class CryptoPayAdapter : IPaymentGateway
{
    public bool ProccesPayment(double amount, string currency)
    {
        
        Console.WriteLine($"Processing payment via CryptoPay: {amount} {currency}");
        return true;
    }
}