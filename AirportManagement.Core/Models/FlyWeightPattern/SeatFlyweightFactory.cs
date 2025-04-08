using AirportManagement.Core.Enums;

namespace AirportManagement.Core.Models.FlyWeightPattern;

public class SeatFlyweightFactory
{
    private readonly Dictionary<SeatType, SeatDetailes> _flyweights = new();

    public SeatDetailes GetSeatDetailes(SeatType type)
    {
        if (!_flyweights.ContainsKey(type))
        {
            string features = type switch
            {
                SeatType.Business => "Reclinable, extra legroom",
                SeatType.Economic => "Standard Seat",
                SeatType.FirstClass => "FirstClass seat",
                _ => "Default seat"
            };

            _flyweights[type] = new SeatDetailes(type, features);
        }

        return _flyweights[type];
    }

    public int Count => _flyweights.Count;
}