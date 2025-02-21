using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportManagement.Core.Enums;

namespace AirportManagement.Core.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  
        public string FlightNumber { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public FlightStatus Status { get; set; }
        
        public Flight(string flightNumber, string destination, DateTime departureTime)
        {
            FlightNumber = flightNumber;
            Destination = destination;
            DepartureTime = departureTime;
        }
    }
}