type SpinnerProps = {
    type: "primary" | "secondary";
};

function Spinner({ type }: SpinnerProps) {
    return (<div className={`spinner-border text-${type}`} role="status"><span className="visually-hidden">Loading...</span></div>);
}

export default Spinner