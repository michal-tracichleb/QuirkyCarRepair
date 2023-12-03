import styles from "./SideBar.module.css";

export function SideBar({children, listFunction}){
    return(
        <div className={styles.sidebar}>
            <div className={styles.sidebar_title}>
                <span>{children}</span>
            </div>
            {listFunction}
        </div>
    )
}