using ZARoutePlanner.Core;

namespace ZARoutePlanner.Api;

public static class ProgramUtils
{
    public static void AddRoutesGraph(this IServiceCollection services, string routesDataFile)
    {
        var linesDataJson = File.ReadAllText(routesDataFile);
        var graph = GraphBuilder.FromJson(linesDataJson);

        services.AddSingleton(graph);
    }
}