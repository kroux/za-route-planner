namespace ZARoutePlanner.Core.Test;

public class GraphTests
{
    [Fact]
    public void Graph_TryGetNode_Returns_True_WhenNodeFound()
    {
        // Arrange
        var graph = TestDataUtils.Lines1Graph;
        const string nodeName = "Station A";

        // Act
        var found = graph.TryGetNode(nodeName, out var node);

        // Assert
        Assert.True(found);
        Assert.Equal(nodeName, node!.Value.Name);
    }

    [Fact]
    public void Graph_TryGetNode_Returns_False_WhenNodeNotFound()
    {
        // Arrange
        var graph = TestDataUtils.Lines1Graph;
        const string nodeName = "Non-existent node";

        // Act
        var found = graph.TryGetNode(nodeName, out var node);

        // Assert
        Assert.False(found);
        Assert.Equal(default(Node), node);
    }
}