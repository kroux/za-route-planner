type AlertProps = {
  type: "danger",
  text: string
};

function Alert({ type, text }: AlertProps) {
  return <div className={`alert alert-${type}`} role="alert">
    {text}
  </div>
}

export default Alert