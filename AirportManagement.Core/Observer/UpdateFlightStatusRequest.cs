using AirportManagement.Core.Enums;

namespace AirportManagement.Core.Observer;

public class UpdateFlightStatusRequest
{
    public UpdateFlightStatusRequest(string flightNumber)
    {
        FlightNumber = flightNumber;
    }

    public string FlightNumber { get; set; }
    public FlightStatus NewStatus { get; set; }
}