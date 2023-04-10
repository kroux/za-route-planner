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
    public Trip? Get(string start, string destination)
    {
        var trip = _routesService.GetRoutes(start, destination);
        return trip;
    }
}