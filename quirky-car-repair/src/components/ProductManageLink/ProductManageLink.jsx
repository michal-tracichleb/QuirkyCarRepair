import styles from "./ProductManageLink.module.css"
export function ProductManageLink({children, to, onClick}){
    const linkProps = {};
    if(to){
        linkProps.href = to;
    }
    if (onClick) {
        linkProps.onClick = onClick;
    }

    return(
        <a className={styles.manageLink} {...linkProps}>{children}</a>
    )
}