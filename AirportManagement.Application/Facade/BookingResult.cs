using AirportManagement.Core.Models;

namespace AirportManagement.Application.Facade;

public class BookingResult
{
    public BookingResult() { }

    public BookingResult(bool success, string message, Ticket ticket)
    {
        Success = success;
        Message = message;
        Ticket = ticket;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public Ticket Ticket { get; set; }
}