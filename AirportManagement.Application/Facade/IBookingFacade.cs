using AirportManagement.Core.Models;

namespace AirportManagement.Application.Facade;

public interface IBookingFacade
{
    Task<BookingResult> BookFlightAsync(BookingRequest request);
}
