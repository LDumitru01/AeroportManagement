using AirportManagement.Application.Services.PaymentAdapters;

namespace AirportManagement.Application.Facade;

public class PaymentFactory : IPaymentFactory
{
    public IPaymentGateway CreatePaymentGateway(string method)
    {
        switch (method.ToLower())
        {
            case "paypal":
                return new PayPalGateway();
            case "stripe":
                return new StripeGateway();
            default:
                throw new Exception($"Unknown payment method: {method}");
        }
    }
}