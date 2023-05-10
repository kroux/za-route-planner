using Microsoft.AspNetCore.Mvc;
using ZARoutePlanner.Api.Services;
using static ZARoutePlanner.Api.Errors.ErrorMessages;

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

        if (!node1Exists)
        {
            ModelState.AddModelError(nameof(start), StationDoesNotExistMessage(start));
        }

        if (!node2Exists)
        {
            ModelState.AddModelError(nameof(destination), StationDoesNotExistMessage(destination));
        }

        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var trip = _routesService.GetRoutes(start, destination);
        return Ok(trip);
    }
}