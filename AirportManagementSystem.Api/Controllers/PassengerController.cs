using AirportManagement.Core.State;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagementSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PassengerController : ControllerBase
{
    private static PassengerContext _passengerContext = new PassengerContext();

    [HttpGet("status")]
    public IActionResult GetStatus()
    {
        return Ok(new { Status = _passengerContext.GetStatus() });
    }

    [HttpPost("checkin")]
    public IActionResult CheckIn()
    {
        try
        {
            _passengerContext.CheckIn();
            return Ok(new { Message = "Passenger checked in.", Status = _passengerContext.GetStatus() });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    [HttpPost("board")]
    public IActionResult Board()
    {
        try
        {
            _passengerContext.Board();
            return Ok(new { Message = "Passenger boarded.", Status = _passengerContext.GetStatus() });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}