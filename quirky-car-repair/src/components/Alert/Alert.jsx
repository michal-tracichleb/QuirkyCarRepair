import styles from "./Alert.module.css"
export function Alert({children, color = "primary"}){
    return(
        <div className={`alert alert-${color} ${styles.myalert}`} role="alert">
            <span>{children}</span>
        </div>
    )
}