using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportManagement.Core.Enums;
using AirportManagement.Core.Visitor;

namespace AirportManagement.Core.Models
{
    public partial class Flight : IVisitable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  
        public string FlightNumber { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public FlightStatus Status { get; set; }
        public decimal Price { get; set; }
        public bool IsInternational { get; set; }

        public Flight(string flightNumber, string destination, DateTime departureTime, decimal price)
        {
            FlightNumber = flightNumber;
            Destination = destination;
            DepartureTime = departureTime;
            Price = price;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitFlight(this);
        }
    }
}