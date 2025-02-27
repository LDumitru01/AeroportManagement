namespace AirportManagement.Core.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        
        public Passenger(string firstName, string lastName, string passportNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PassportNumber = passportNumber;
        }
        
        public Passenger() {}
    }
}