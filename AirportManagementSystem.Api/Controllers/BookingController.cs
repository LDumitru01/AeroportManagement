using AirportManagement.Application.Facade;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagementSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly IBookingFacade _bookingFacade;

    public BookingController(IBookingFacade bookingFacade)
    {
        _bookingFacade = bookingFacade;
    }

    [HttpPost("book")]
    public async Task<IActionResult> BookFlight([FromBody] BookingRequest request)
    {
        var result = await _bookingFacade.BookFlightAsync(request);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(new
        {
            result.Message,
            result.Ticket
        });
    }
}