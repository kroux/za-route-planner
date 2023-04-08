namespace ZARoutePlanner.Core.Planner;

public class TripLeg
{
    /// <summary>
    /// The description of the trip leg.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The route followed from the start to the destination of the trip leg.
    /// </summary>
    public List<string> Route { get; init; }
}