using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Core.Enums;
using AirportManagement.Core.Models;

namespace AirportManagement.Application.Facade;

public class BookingFacade : IBookingFacade
{
    private readonly IFlightService _flightService;
    private readonly ITicketService _ticketService;
    private readonly IPaymentFactory _paymentFactory;

    public BookingFacade(IFlightService flightService,
        ITicketService ticketService,
        IPaymentFactory paymentFactory)
    {
        _flightService = flightService;
        _ticketService = ticketService;
        _paymentFactory = paymentFactory;
    }

    public async Task<BookingResult> BookFlightAsync(BookingRequest request)
    {
        var flight = await _flightService.GetFlightByIdAsync(request.FlightId);
        var paymentGateway = _paymentFactory.CreatePaymentGateway(request.PaymentMethod);
        bool paymentOk = paymentGateway.ProcessPayment(request.AmountToPay, "USD");
        if (!paymentOk)
        {
            return new BookingResult
            {
                Success = false,
                Message = "Payment failed"
            };
        }

        
        var ticket = await _ticketService.CreateTicketAsync(
            flight.Id,
            request.FirstName,
            request.LastName,
            request.PassportNumber,
            MealType.Business,
            SeatType.Business       
        );

        
        return new BookingResult
        {
            Success = true,
            Message = "Flight booked successfully!",
            Ticket = ticket
        };
    }
}