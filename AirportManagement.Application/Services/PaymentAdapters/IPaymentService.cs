namespace AirportManagement.Application.Services.PaymentAdapters;

public interface IPaymentService
{
    bool PayForTicket(double amount, string currency);
}