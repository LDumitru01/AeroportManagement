using AirportManagement.Application.Services.PaymentAdapters;

namespace AirportManagement.Application.Facade;

public interface IPaymentFactory
{
    IPaymentGateway CreatePaymentGateway(string method);
}