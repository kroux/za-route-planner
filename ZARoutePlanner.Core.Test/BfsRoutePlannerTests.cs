using ZARoutePlanner.Core.Planner;

namespace ZARoutePlanner.Core.Test;

public class BfsRoutePlannerTests
{
    [Fact]
    public void Constructor_ThrowsException_WhenGraphIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new BfsRoutePlanner(null!));
    }

    [Fact]
    public void TryGetRoute_ThrowsException_WhenStartIsNull()
    {
        // Arrange
        var graph = new Graph();
        var planner = new BfsRoutePlanner(graph);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => planner.TryGetRoute(null!, "Station A", out _));
    }

    [Fact]
    public void TryGetRoute_ThrowsException_WhenDestinationIsNull()
    {
        // Arrange
        var graph = new Graph();
        var planner = new BfsRoutePlanner(graph);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => planner.TryGetRoute("Station A", null!, out _));
    }

    [Fact]
    public void TryGetRoute_ReturnsFalse_WhenNoRouteFound()
    {
        // Arrange
        var graph = TestDataUtils.Lines1Graph;
        var planner = new BfsRoutePlanner(graph);

        // Act
        var isRouteFound = planner.TryGetRoute("Station A", "Non-existing station", out _);

        // Assert
        Assert.False(isRouteFound);
    }

    [Fact]
    public void BfsRoutePlanner_PlanRouteCorrectly_ForLines1()
    {
        // Arrange
        var graph = TestDataUtils.Lines1Graph;
        const string start = "Station A";
        const string destination = "Station E";

        // Act
        var routePlanner = new BfsRoutePlanner(graph);
        var isRouteFound = routePlanner.TryGetRoute(start, destination, out var paths);

        // Assert
        Assert.True(isRouteFound);
        Assert.Equal(new Dictionary<string, List<(string sourceNode, string path)>>
        {
            { "Station A", null! },
            { "Station E", new() { ("Station A", "Line C") } },
            { "Station B", new() { ("Station A", "Line A") } },
        }, paths);
    }
}