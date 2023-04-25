# za-route-planner

A route planning application as basis for exploring various tools, frameworks, and graph algorithms.

**Please note**: This project is for education purposes only and should not be used for any actual route planning.

## Project Features

- A ReactJS frontend that calls the route planning API

### Algorithms

- Breadth-first search (capable of finding the shortest route if we assume that distances between all stations are equal
  and there is no cost to switching lines)

### Other

- Tries to follow the _Problem Details for HTTP APIs_ ([RFC 7807](https://datatracker.ietf.org/doc/html/rfc7807))
  specification for returning API errors.

## Project Setup

### Project Requirements

1. The .NET 7 SDK
2. NodeJS 18

### Running the project

1. Run `dotnet run` from the `ZARoutePlanner.Api/` directory;
2. Run `npm install` from the `client/` directory; and
3. Run `npm run dev` from the `client/` directory.

A new window opens in your browser where you can enter your `From` to `To` stations. Click `Search` to calculate a route
between the two stations.
