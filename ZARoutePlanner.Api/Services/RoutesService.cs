using ZARoutePlanner.Core;
using ZARoutePlanner.Core.Planner;

namespace ZARoutePlanner.Api.Services;

public class RoutesService
{
    private readonly Graph _graph;
    private readonly BfsRoutePlanner _bfsRoutePlanner;

    public RoutesService(Graph graph)
    {
        _graph = graph;
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

    public (bool, bool) ValidateNodesExist(string nodeName1, string nodeName2)
    {
        var nodeName1Exists = _graph.TryGetNode(nodeName1, out _);
        var nodeName2Exists = _graph.TryGetNode(nodeName2, out _);

        return (nodeName1Exists, nodeName2Exists);
    }
}