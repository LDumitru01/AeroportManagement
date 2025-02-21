using AirportManagement.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public IActionResult CreateReservation([FromBody] string type)
        {
            var reservation = _reservationService.CreateReservation(type);
            return Ok(reservation.GetReservationDetails());
        }
    }
}