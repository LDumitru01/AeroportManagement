using AirportManagement.Core.Enums;

namespace AirportManagement.Application.Models;

public class CheckInRequestDto
{
    public CheckInRequestDto(int ticketId, CheckInType type, string cnp, PassportType passportType, DateTime dateOfBirth)
    {
        TicketId = ticketId;
        Type = type;
        Cnp = cnp;
        PassportType = passportType;
        DateOfBirth = dateOfBirth;
    }

    public int TicketId { get; set; }
    public CheckInType Type { get; set; }           
    public string Cnp { get; set; }
    public PassportType PassportType { get; set; }  
    public DateTime DateOfBirth { get; set; }
}