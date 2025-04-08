using AirportManagement.Core.Enums;

namespace AirportManagement.Core.Observer;

public class UpdateFlightStatusRequest
{
    public int FlightId { get; set; }
    public FlightStatus NewStatus { get; set; }
}