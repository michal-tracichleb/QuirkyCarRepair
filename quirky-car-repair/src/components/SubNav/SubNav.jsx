import styles from "../WarehouseSidebarContent/WarehouseSidebarContent.module.css";
import {useState} from "react";

export function SubNav({children, title, to}){
    const [subnav, setSubnav] = useState(false);
    const showSubnav = () => setSubnav(!subnav);
    const linkProps = {};
    if(to){
        linkProps.href = to;
    }
    return(
        <>
            <a className={styles.SidebarLink} onClick={showSubnav} {...linkProps}>
                <span className={styles.SidebarLabel}>{title}</span>
            </a>
            {subnav && children &&
                <div className={styles.dropDown}>
                    {children}
                </div>
            }
        </>

    )
}
