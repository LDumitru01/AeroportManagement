using AirportManagement.Core.Enums;

namespace AirportManagement.Core.Models.FlyWeightPattern;

public class SeatDetailes
{
    public SeatType Type { get; }
    public string Futeures { get; }

    public SeatDetailes(SeatType type, string futeures)
    {
        Type = type;
        Futeures = futeures;
    }

}