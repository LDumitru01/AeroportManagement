namespace AirportManagement.Application.Services.PaymentAdapters;

public class PeymentService: IPaymentService
{
    private readonly IPaymentGateway _paymentGateway;

    public PeymentService(IPaymentGateway paymentGateway)
    {
        _paymentGateway = paymentGateway;
    }

    public bool PayForTicket(double amount, string currency)
    {
        return _paymentGateway.ProccesPayment(amount, currency);
    }
}