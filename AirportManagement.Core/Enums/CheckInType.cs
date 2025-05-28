using System.Text.Json.Serialization;

namespace AirportManagement.Core.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CheckInType
{
    Standard,
    Business,
    VIP
}