import { FormEvent, useEffect, useState } from "react";

type SearchFormProps = {
  onSearch: (from: string, to: string) => void,
  from?: string,
  to?: string
};

function RoutesSearchForm({ onSearch, from = "", to = "" }: SearchFormProps) {
  const [fromValue, setFromValue] = useState(from);
  const [toValue, setToValue] = useState(to);

  useEffect(() => {
    document.getElementById("search-from-input")?.focus();
  }, []);

  function handleSubmit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();
    onSearch(fromValue, toValue);
  }

  return (
    <form id="route-search-form" data-testid="form" onSubmit={handleSubmit}>
      <div className="mb-2">
        <label htmlFor="search-from-input" className="form-label">From</label>
        <input id="search-from-input" data-testid="search-from-input" type="text" value={fromValue} onChange={(e) => setFromValue(e.currentTarget.value)} className="form-control" />
      </div>
      <div className="mb-2">
        <label htmlFor="search-to-input" className="form-label">To</label>
        <input id="search-to-input" type="text" value={toValue} onChange={(e) => setToValue(e.currentTarget.value)} className="form-control" />
      </div>
      <div className="mb-2">
        <button type="submit" className="btn btn-primary">Search</button>
      </div>
    </form>
  );
}

export default RoutesSearchForm