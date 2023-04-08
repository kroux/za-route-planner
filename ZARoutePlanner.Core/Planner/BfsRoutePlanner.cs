namespace ZARoutePlanner.Core.Planner;

public class BfsRoutePlanner
{
    private readonly Graph _graph;

    public BfsRoutePlanner(Graph graph)
    {
        _graph = graph ?? throw new ArgumentNullException(nameof(graph));
    }

    public bool TryGetRoute(string start, string destination,
        out Dictionary<string, List<(string sourceNode, string path)>> path)
    {
        if (start == null) throw new ArgumentNullException(nameof(start));
        if (destination == null) throw new ArgumentNullException(nameof(destination));

        // Keep track of visited nodes
        var visited = new HashSet<Node>();

        // For each node, keep track of the (Node, Edge) combinations that were able to reach it.
        path = new Dictionary<string, List<(string sourceNode, string path)>>();

        // Queue to determine which nodes to visit next.
        var queue = new Queue<Node>();

        var currentNode = _graph.GetNode(start);
        queue.Enqueue(currentNode);
        path.Add(currentNode.Name, null!);

        while (queue.Count > 0)
        {
            currentNode = queue.Dequeue();

            if (visited.Contains(currentNode))
            {
                continue;
            }

            visited.Add(currentNode);

            if (currentNode.Name == destination)
            {
                // The destination node was found.
                return true;
            }

            foreach (var edge in currentNode.Edges.OrderByDescending(e => e.Description))
            {
                if (!visited.Contains(edge.Destination))
                {
                    queue.Enqueue(edge.Destination);

                    var routesExist = path.TryGetValue(edge.Destination.Name, out var paths);
                    if (!routesExist)
                    {
                        path.Add(edge.Destination.Name, new() { (currentNode.Name, edge.Description) });
                    }
                    else
                    {
                        paths!.Add((currentNode.Name, edge.Description));
                    }
                }
            }
        }

        return false;
    }
}