namespace AirportManagement.Core.Models;

public class CloneTicketRequest
{
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PassportNumber { get; set; }
    
    public CloneTicketRequest(string firstName, string lastName, string passportNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PassportNumber = passportNumber;
    }
}