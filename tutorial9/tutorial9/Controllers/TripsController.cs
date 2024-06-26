using Microsoft.AspNetCore.Mvc;
using tutorial9.DTO_s;
using tutorial9.Services;

namespace tutorial9.Controllers;

[Route("api/trips")]
[ApiController]
public class TripsController : ControllerBase
{
    private ITripsService _tripsService;

    public TripsController(ITripsService tripsService)
    {
        _tripsService = tripsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrips(string? query, int? page, int? pageSize) // '?' - nullable
    {
        var result = await _tripsService.GetTrips(query, page, pageSize);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var result = await _tripsService.DeleteClient(id);
        return Ok(result);
    }

    [HttpPost("{tripId:int}/clients")]
    public async Task<IActionResult> AssignClientToTrip(int tripId, AddClientDto client)
    {
        var result = await _tripsService.AssignClientToTrip(tripId, client);
        return Ok(result);
    }
}