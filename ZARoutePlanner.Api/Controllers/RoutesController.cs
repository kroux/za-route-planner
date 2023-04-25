using Microsoft.AspNetCore.Mvc;
using ZARoutePlanner.Api.Services;

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
            ModelState.AddModelError(nameof(start), $"The specified station '{start}' does not exist.");
        }

        if (!node2Exists)
        {
            ModelState.AddModelError(nameof(destination), $"The specified station '{destination}' does not exist.");
        }

        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var trip = _routesService.GetRoutes(start, destination);
        return Ok(trip);
    }
}