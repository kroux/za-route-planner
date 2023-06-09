using Microsoft.AspNetCore.Mvc;
using ZARoutePlanner.Core;

namespace ZARoutePlanner.Api.Controllers;

[ApiController]
[Route("stations")]
public class StationsController : ControllerBase
{
    private readonly Graph _graph;

    public StationsController(Graph graph)
    {
        _graph = graph;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var stations = _graph.Nodes.Select(n => n.Name).Distinct().Order();

        return Ok(stations);
    }
}