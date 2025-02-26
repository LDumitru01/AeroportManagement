using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportManagement.Core.Models;

public class Reservation
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int FlightId { get; set; }
    [ForeignKey("FlightId")]
    public Flight? Flight { get; set; }
    [Required]
    public string? PassengerName { get; set; }
    [Required]
    public string? PassportNumber { get; set; }
    [Required]
    public DateTime ReservationtDate { get; set; }
}