using System.Text.Json;

namespace ZARoutePlanner.Core;

public static class GraphBuilder
{
    public static Graph FromJson(string json)
    {
        var lineInfo = JsonSerializer.Deserialize<Dictionary<string, string[]>>(json);

        var graph = new Graph();

        foreach (var (lineName, stops) in lineInfo)
        {
            for (var i = 0; i < stops.Length; i++)
            {
                graph.AddNode(stops[i]);
                if (i > 0)
                {
                    graph.AddEdge(stops[i - 1], stops[i], lineName);
                    graph.AddEdge(stops[i], stops[i - 1], lineName);
                }
            }
        }

        return graph;
    }
}