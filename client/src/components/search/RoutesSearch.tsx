import { useState } from "react";
import RoutesSearchForm from "./RoutesSearchForm";
import RoutesSearchResults, { RouteSearchResultType } from "./RoutesSearchResults";
import Spinner from "../Spinner";
import Alert from "../Alert";

function RoutesSearch() {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');
  const [hasError, setHasError] = useState(false);
  const [results, setResults] = useState<RouteSearchResultType[]>([]);

  async function handleSearch(from: string, to: string) {
    setLoading(true);
    setError('');
    setHasError(false);

    try {
      var result = await fetch(`http://localhost:5123/routes?start=${from}&destination=${to}`);
      if (result.status === 200) {
        const searchResult = await result.json();
        setResults([searchResult]);
        setLoading(false);
        setHasError(false);

        /**
         * Scroll to the result element, but not immediately
         * because React might not have rendered the element.
         */
        setTimeout(() => {
          const elem = document.getElementById("routes-search-results");
          elem?.scrollIntoView({ behavior: "smooth" });
        }, 100);
      } else if (result.status === 400) {
        setLoading(false);
        setHasError(true);

        const response = await result.json();
        setError(response.detail);
      } else {
        setLoading(false);
        setHasError(true);
      }
    } catch (error) {
      console.error(error);
      setLoading(false);
      setHasError(true);
    }

  }

  return (
    <div>
      <RoutesSearchForm onSearch={handleSearch} />
      {loading && <Spinner type="primary" />}
      {!loading && !hasError && <RoutesSearchResults results={results} />}
      {hasError && <Alert type="danger" text={error || "Something went wrong, please try again later."} />}
    </div>
  );
}

export default RoutesSearch