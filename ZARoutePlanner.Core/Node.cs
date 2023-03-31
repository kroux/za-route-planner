namespace ZARoutePlanner.Core;

public readonly record struct Node(string Name)
{
    public HashSet<Edge> Edges { get; } = new();
}