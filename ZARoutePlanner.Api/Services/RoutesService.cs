using ZARoutePlanner.Core;
using ZARoutePlanner.Core.Planner;

namespace ZARoutePlanner.Api.Services;

public class RoutesService
{
    private const string LinesData = "Lines.json";

    private readonly BfsRoutePlanner _bfsRoutePlanner;

    public RoutesService(ILogger<RoutesService> logger)
    {
        logger.LogInformation("Loading data from {DataFile}", LinesData);
        var linesDataJson = File.ReadAllText(LinesData);

        logger.LogInformation("Building graph");
        var graph = GraphBuilder.FromJson(linesDataJson);

        _bfsRoutePlanner = new BfsRoutePlanner(graph);
    }

    public Trip? GetRoutes(string start, string destination)
    {
        var routeFound = _bfsRoutePlanner.TryGetRoute(start, destination, out var path);
        if (!routeFound)
        {
            return null;
        }

        var trip = PlannerUtils.GetTrip(start, destination, path);

        return trip;
    }
}