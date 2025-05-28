namespace AirportManagement.Application.Models;

public class PaymentRequestDto
{
    public int TicketId { get; set; } 
    public double Amount { get; set; }
    public string Currency { get; set; } = "EUR";
    public string Method { get; set; } = "";    
}