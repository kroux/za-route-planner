namespace ZARoutePlanner.Core.Planner;

public static class PlannerUtils
{
    public static Trip? GetTrip(string start, string destination,
        Dictionary<string, List<(string sourceNode, string path)>> paths)
    {
        if (start == null) throw new ArgumentNullException(nameof(start));
        if (destination == null) throw new ArgumentNullException(nameof(destination));
        if (paths == null) throw new ArgumentNullException(nameof(paths));

        var trip = new Trip
        {
            Start = start,
            Destination = destination,
            Legs = new List<TripLeg>()
        };

        var destinationPath = paths[destination];
        var currentRoutes = destinationPath;

        var currentLine = currentRoutes.First().path;

        var currentTripLeg = new TripLeg
        {
            Description = currentLine,
            Route = new List<string>()
        };
        trip.Legs.Add(currentTripLeg);
        var currentLegRoute = currentTripLeg.Route;

        currentLegRoute.Add(destination);

        while (currentRoutes != null)
        {
            var (currentNode, currentDescription) = currentRoutes.First();

            if (currentLine != currentDescription)
            {
                currentLine = currentDescription;
                currentLegRoute.Reverse();

                currentLegRoute = new List<string> { currentLegRoute.First(), currentNode };
                currentTripLeg = new TripLeg
                {
                    Description = currentDescription,
                    Route = currentLegRoute
                };
                trip.Legs.Add(currentTripLeg);
            }
            else
            {
                currentLegRoute.Add(currentNode);
            }

            currentRoutes = paths[currentNode];
        }

        currentLegRoute.Reverse();
        trip.Legs.Reverse();

        return trip;
    }
}