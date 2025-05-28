using AirportManagement.Application.Repository;
using AirportManagement.Application.Services.PaymentAdapters;
using AirportManagement.Core.Enums;

namespace AirportManagement.Application.Facade;

public class StripeGateway : IPaymentGateway
{
    private readonly TicketRepository _ticketRepository;
    public async Task<bool> ProcessPaymentAsync(int ticketId, double amount, string currency)
    {
        var ticket = await _ticketRepository.GetTicketByIdAsync(ticketId);
        if (ticket == null || ticket.IsPaid)
            return false;

        ticket.IsPaid = true;
        ticket.PaidAmount = (decimal)amount;
        ticket.PaymentMethod = PaymentMethod.Crypto;

        await _ticketRepository.UpdateAsync(ticket);
        return true;
    }
}