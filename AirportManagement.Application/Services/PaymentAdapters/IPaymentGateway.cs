namespace AirportManagement.Application.Services.PaymentAdapters;

public interface IPaymentGateway
{
    bool ProcessPayment(double amount, string currency);
}