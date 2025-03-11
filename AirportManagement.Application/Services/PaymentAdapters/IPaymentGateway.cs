namespace AirportManagement.Application.Services.PaymentAdapters;

public interface IPaymentGateway
{
    bool ProccesPayment(double amount, string currency);
}