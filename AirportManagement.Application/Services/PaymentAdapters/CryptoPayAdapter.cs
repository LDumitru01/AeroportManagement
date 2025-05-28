using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Core.Enums;

namespace AirportManagement.Application.Services.PaymentAdapters;

public class CryptoPayAdapter : IPaymentGateway
{
    private readonly ITicketRepository _ticketRepository;

    public CryptoPayAdapter(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<bool> ProcessPaymentAsync(int ticketId, double amount, string currency)
    {
        var ticket = await _ticketRepository.GetTicketByIdAsync(ticketId);
        if (ticket == null || ticket.IsPaid)
            return false;

        // Verifică dacă suma introdusă este egală cu prețul real
        if (ticket.Flight != null && (decimal)amount != ticket.Flight.Price)
            return false;

        ticket.IsPaid = true;
        ticket.PaidAmount = (decimal)amount;
        ticket.PaymentMethod = PaymentMethod.Crypto;

        await _ticketRepository.UpdateAsync(ticket);
        return true;
    }

}
