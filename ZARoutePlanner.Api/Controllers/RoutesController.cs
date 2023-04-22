using Microsoft.AspNetCore.Mvc;
using ZARoutePlanner.Api.Services;
using ZARoutePlanner.Core.Planner;

namespace ZARoutePlanner.Api.Controllers;

[ApiController]
[Route("routes")]
public class RoutesController : ControllerBase
{
    private readonly RoutesService _routesService;

    public RoutesController(RoutesService routesService)
    {
        _routesService = routesService;
    }

    [HttpGet]
    public IActionResult Get(string start, string destination)
    {
        var (node1Exists, node2Exists) = _routesService.ValidateNodesExist(start, destination);

        switch (node1Exists, node2Exists)
        {
            case (false, false):
                return Problem(title: "Stations not found",
                    detail: $"The specified station {start} or {destination} were not found.",
                    statusCode: StatusCodes.Status400BadRequest);
            case (true, false):
                return Problem(title: "Stations not found",
                    detail: $"The specified station {destination} was not found.",
                    statusCode: StatusCodes.Status400BadRequest);
            case (false, true):
                return Problem(title: "Stations not found",
                    detail: $"The specified station {destination} was not found.",
                    statusCode: StatusCodes.Status400BadRequest);
        }

        var trip = _routesService.GetRoutes(start, destination);
        return Ok(trip);
    }
}