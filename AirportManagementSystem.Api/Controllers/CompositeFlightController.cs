using AirportManagement.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagementSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompositeFlightController : ControllerBase
{
    private readonly ICompositeFlightService _compositeFlightService;

    public CompositeFlightController(ICompositeFlightService compositeFlightService)
    {
        _compositeFlightService = compositeFlightService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateComposite([FromBody] List<int> flightIds)
    {
        var composite = await _compositeFlightService.BuildCompositeFlightAsync(flightIds);
        return Ok(new
        {
            details = composite.GetFlightDetails(),
            price = composite.GetPrice()
        });
    }
}