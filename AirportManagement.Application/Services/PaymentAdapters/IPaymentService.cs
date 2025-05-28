namespace AirportManagement.Application.Services.PaymentAdapters;

public class PaymentService
{
    private readonly IPaymentGateway _gateway;

    public PaymentService(IPaymentGateway gateway)
    {
        _gateway = gateway;
    }

    public async Task<bool> PayForTicket(int ticketId, double amount, string currency)
    {
        return await _gateway.ProcessPaymentAsync(ticketId, amount, currency);
    }
}
