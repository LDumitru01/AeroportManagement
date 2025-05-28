using System.Security.Claims;
using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace AirportManagement.Application.Facade;

public class BookingFacade : IBookingFacade
{
    private readonly IFlightService _flightService;
    private readonly ITicketService _ticketService;
    private readonly IPaymentFactory _paymentFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BookingFacade(IFlightService flightService,
        ITicketService ticketService,
        IPaymentFactory paymentFactory, IHttpContextAccessor httpContextAccessor)
    {
        _flightService = flightService;
        _ticketService = ticketService;
        _paymentFactory = paymentFactory;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<BookingResult> BookFlightAsync(BookingRequest request)
    {
        var flight = await _flightService.GetFlightByNumberAsync(request.FlightNumber);
        var email = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
        if (string.IsNullOrEmpty(email))
            throw new UnauthorizedAccessException("Utilizatorul nu este autentificat.");

        if (flight != null)
        {
            var ticket = await _ticketService.CreateTicketAsync(
                email,
                flight.FlightNumber,
                request.FirstName,
                request.LastName,
                request.PassportNumber,
                MealType.Business,
                SeatType.Business
            );

            var paymentGateway = _paymentFactory.CreatePaymentGateway(request.PaymentMethod);
            bool paymentOk = await paymentGateway.ProcessPaymentAsync(ticket.Id, request.AmountToPay, "USD");

            if (!paymentOk)
            {
                return new BookingResult
                {
                    Success = false,
                    Message = "Payment failed"
                };
            }
        }
        
        return new BookingResult
        {
            Success = false,
            Message = "Zborul nu a fost găsit"
        };
    }
}