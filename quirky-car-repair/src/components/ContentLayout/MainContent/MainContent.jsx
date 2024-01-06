import styles from "./MainContent.module.css";

export function MainContent({children}){
    return(
        <div className={styles.wrapper}>
            {children}
        </div>
    )
}