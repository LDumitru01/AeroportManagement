using AirportManagement.Core.Visitor;

namespace AirportManagement.Core.Models
{
    public class Passenger : IVisitable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public bool IsVip { get; set; } = false;

        public Passenger(string firstName, string lastName, string passportNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PassportNumber = passportNumber;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitPassenger(this);
        }
    }
}