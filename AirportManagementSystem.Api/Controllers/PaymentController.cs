using AirportManagement.Application.Services.PaymentAdapters;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagementSystem.Api.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentController : ControllerBase
{
    [HttpPost("pay")]
    public IActionResult Pay([FromQuery] double amount, [FromQuery] string currency, [FromQuery] string method)
    {
        IPaymentGateway paymentGateway;
        
        switch (method.ToLower())
        {
            case "paypal":
                paymentGateway = new PayPalAdapters();
                break;
            case "CryptoPay":
                paymentGateway = new CryptoPayAdapter();
                break;
            case "googlepay":
                paymentGateway = new GooglePayAdapter();
                break;
            default:
                return BadRequest("Invalid payment method.");
        }

        var paymentService = new PeymentService(paymentGateway);
        bool success = paymentService.PayForTicket(amount, currency);

        return success ? Ok("Payment Successful") : BadRequest("Payment Failed");
    }
}