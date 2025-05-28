using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Application.Models;
using AirportManagement.Application.Services.PaymentAdapters;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagementSystem.Api.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentController : ControllerBase
{
    private readonly ITicketRepository _ticketRepository;

    public PaymentController(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    [HttpPost("pay")]
    public async Task<IActionResult> PayForTicket([FromBody] PaymentRequestDto dto)
    {
        IPaymentGateway gateway = dto.Method.ToLower() switch
        {
            "paypal" => new PayPalAdapters(_ticketRepository),
            "googlepay" => new GooglePayAdapter(_ticketRepository),
            "crypto" => new CryptoPayAdapter(_ticketRepository),
            _ => throw new ArgumentException("Metodă invalidă")
        };

        var paymentService = new PaymentService(gateway);
        var success = await paymentService.PayForTicket(dto.TicketId, dto.Amount, dto.Currency);

        return success
            ? Ok("Plata reușită!")
            : BadRequest("Eroare la plată.");
    }
}
