namespace ZARoutePlanner.Core;

public class Graph
{
    private readonly HashSet<Node> _nodes = new();

    public void AddNode(string name)
    {
        var exists = _nodes.Contains(new Node(name));
        if (!exists)
        {
            _nodes.Add(new Node(name));
        }
    }

    public void AddEdge(string from, string to, string description)
    {
        var startNode = _nodes.First(n => n.Name == from);
        var endNode = _nodes.First(n => n.Name == to);

        startNode.Edges.Add(new Edge(endNode, description));
    }

    public Node GetNode(string name)
    {
        return _nodes.First(n => n.Name == name);
    }

    public bool TryGetNode(string name, out Node? node)
    {
        node = _nodes.FirstOrDefault(n => n.Name == name);
        return !Equals(default(Node), node);
    }
}