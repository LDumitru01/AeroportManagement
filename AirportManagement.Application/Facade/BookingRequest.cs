using System.Text.Json.Serialization;

namespace AirportManagement.Application.Facade;

public class BookingRequest
{
    [JsonConstructor]
    public BookingRequest(int flightId, string firstName, string lastName, string passportNumber, double amountToPay, string paymentMethod)
    {
        FlightId = flightId;
        FirstName = firstName;
        LastName = lastName;
        PassportNumber = passportNumber;
        AmountToPay = amountToPay;
        PaymentMethod = paymentMethod;
    }

    public int FlightId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PassportNumber { get; set; }
    public double AmountToPay { get; set; }
    public string PaymentMethod { get; set; }
}