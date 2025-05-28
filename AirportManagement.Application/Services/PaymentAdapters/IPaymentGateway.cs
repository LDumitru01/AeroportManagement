namespace AirportManagement.Application.Services.PaymentAdapters;

public interface IPaymentGateway
{
    Task<bool> ProcessPaymentAsync(int ticketId, double amount, string currency);
}