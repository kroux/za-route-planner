namespace ZARoutePlanner.Core.Planner;

public class Trip
{
    /// <summary>
    /// The trip start location.
    /// </summary>
    public string Start { get; set; }

    /// <summary>
    /// The trip destination.
    /// </summary>
    public string Destination { get; set; }

    /// <summary>
    /// The number of transfers required to reach the destination.
    /// </summary>
    public int Transfers => Legs.Count() - 1;

    /// <summary>
    /// The number of stop between the start and the destination.
    /// </summary>
    public int Stops => Legs.Sum(l => l.Route.Count - 1);

    /// <summary>
    /// The trip legs.
    /// </summary>
    public List<TripLeg> Legs { get; init; }
}