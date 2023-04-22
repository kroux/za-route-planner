import RouteSearchResult from "./RouteSearchResult";

export type RouteLeg = {
  description: string,
  route: string[]
};

export type RouteSearchResultType = {
  start: string,
  destination: string,
  transfers: number,
  stops: number,
  legs: RouteLeg[]
};

type RouteSearchResultsProps = {
  results: RouteSearchResultType[]
};

function RoutesSearchResults({ results }: RouteSearchResultsProps) {

  return (
    <div id="routes-search-results">
      <h2>Results</h2>
      {results.map((result: RouteSearchResultType, index: number) => <RouteSearchResult key={index} result={result} />)}
    </div>
  );
}

export default RoutesSearchResults;