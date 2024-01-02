import styles from "./Alert.module.css"
export function Alert({children, color = "primary"}){
    return(
        <div className={`${styles[color]} ${styles.myalert}`}>
            <span>{children}</span>
        </div>
    )
}