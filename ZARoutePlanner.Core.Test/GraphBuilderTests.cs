namespace ZARoutePlanner.Core.Test;

public class GraphBuilderTests
{
    [Fact]
    public void GraphBuilder_BuildsCorrectGraph_ForLines1()
    {
        // Arrange
        var lines1Json = TestDataUtils.Lines1Json;

        // Act
        var graph = GraphBuilder.FromJson(lines1Json);

        // Assert
        var stationANode = graph.GetNode("Station A");
        var stationBNode = graph.GetNode("Station B");
        var stationCNode = graph.GetNode("Station C");
        var stationDNode = graph.GetNode("Station D");
        var stationENode = graph.GetNode("Station E");

        Assert.Equal("Station A", stationANode.Name);
        Assert.Equal("Station B", stationBNode.Name);
        Assert.Equal("Station C", stationCNode.Name);
        Assert.Equal("Station D", stationDNode.Name);
        Assert.Equal("Station E", stationENode.Name);

        Assert.Equal(stationANode.Edges, new[] { new Edge(stationBNode, "Line A"), new Edge(stationENode, "Line C") });

        Assert.Equal(stationBNode.Edges,
            new[]
            {
                new Edge(stationANode, "Line A"), new Edge(stationCNode, "Line A"), new Edge(stationDNode, "Line B")
            });

        Assert.Equal(stationCNode.Edges, new[] { new Edge(stationBNode, "Line A") });

        Assert.Equal(stationDNode.Edges, new[] { new Edge(stationBNode, "Line B"), new Edge(stationENode, "Line B") });

        Assert.Equal(stationENode.Edges, new[] { new Edge(stationDNode, "Line B"), new Edge(stationANode, "Line C") });
    }
}