namespace AirportManagement.Application.Services.PaymentAdapters;

public class PeymentService
{
    private readonly IPaymentGateway _paymentGateway;

    public PeymentService(IPaymentGateway paymentGateway)
    {
        _paymentGateway = paymentGateway;
    }

    public Task<bool> PayForTicket(int ticketId, double amount, string currency)
    {
        return _paymentGateway.ProcessPaymentAsync(ticketId, amount, currency);
    }
}