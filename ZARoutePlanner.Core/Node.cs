namespace ZARoutePlanner.Core;

public readonly record struct Node(string Name)
{
    public bool Equals(Node other)
    {
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public HashSet<Edge> Edges { get; } = new();
}