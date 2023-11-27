export function Alert({children, color = "primary"}){
    return(
        <div className={`alert alert-${color}`} role="alert">
            <span>{children}</span>
        </div>
    )
}