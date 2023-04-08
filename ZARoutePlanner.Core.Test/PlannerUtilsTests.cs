using ZARoutePlanner.Core.Planner;

namespace ZARoutePlanner.Core.Test;

public class PlannerUtilsTests
{
    [Fact]
    public void GetTrip_ThrowsException_WhenStartIsNull()
    {
        // Act
        var ex = Record.Exception(() =>
            PlannerUtils.GetTrip(null!, "Destination",
                new Dictionary<string, List<(string sourceNode, string path)>>()));

        // Assert
        TestUtils.IsArgumentNullException(ex!, "start");
    }

    [Fact]
    public void GetTrip_ThrowsException_WhenDestinationIsNull()
    {
        // Act
        var ex = Record.Exception(() =>
            PlannerUtils.GetTrip("Start", null!, new Dictionary<string, List<(string sourceNode, string path)>>()));

        // Assert
        TestUtils.IsArgumentNullException(ex!, "destination");
    }

    [Fact]
    public void GetTrip_ThrowsException_WhenPathIsNull()
    {
        // Act
        var ex = Record.Exception(() => PlannerUtils.GetTrip("Start", "Destination", null!));

        // Assert
        TestUtils.IsArgumentNullException(ex!, "paths");
    }

    [Fact]
    public void GetTrip_BuildCorrectTrip_ForLines1()
    {
        // Arrange
        var graph = TestDataUtils.Lines1Graph;
        var planner = new BfsRoutePlanner(graph);
        const string start = "Station A";
        const string destination = "Station E";
        var routeExists = planner.TryGetRoute(start, destination, out var path);

        // Act
        var trip = PlannerUtils.GetTrip(start, destination, path);

        // Assert
        Assert.True(routeExists);
        Assert.Equal(1, trip.Stops);
        Assert.Equal(0, trip.Transfers);
        Assert.Equivalent(new Trip
        {
            Start = start,
            Destination = destination,
            Legs = new List<TripLeg>
            {
                new()
                {
                    Description = "Line C",
                    Route = new List<string>
                    {
                        "Station A", "Station E"
                    }
                }
            }
        }, trip);
    }
}