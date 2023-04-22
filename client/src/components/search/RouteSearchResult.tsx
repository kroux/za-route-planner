import { RouteLeg, RouteSearchResultType } from "./RoutesSearchResults";

type RouteSearchResultProps = {
  result: RouteSearchResultType
};

function RouteSearchResult({ result }: RouteSearchResultProps) {
  return (
    <div className="card p-3 my-2">
      <p>{result.start} - {result.destination}</p>
      <p>Transfers: {result.transfers}, stops: {result.stops}</p>
      <p className="mb-0">Legs:</p>
      <ul className="mb-0">
        {result.legs.map((leg: RouteLeg, index: number) => <li key={index}><strong>{leg.description}</strong> ({leg.route.join(", ")})</li>)}
      </ul>
    </div>);
}

export default RouteSearchResult;