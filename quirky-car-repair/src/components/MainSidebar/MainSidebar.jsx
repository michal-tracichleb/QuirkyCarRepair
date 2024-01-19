import styles from "./MainSidebar.module.css"
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faXmark} from "@fortawesome/free-solid-svg-icons";
import {NavLink} from "react-router-dom";
import {getSubpages} from "../../utlis/getSubpages.js";
export function MainSidebar({ sidebarIsShown, setSidebarIsShown}) {
    const subpages = getSubpages();
    return (
        <nav className={`${styles.navMenu} ${sidebarIsShown ? styles.active : ''}`}>
            <div className={styles.header}>
                <h1>Menu</h1>
                <FontAwesomeIcon icon={faXmark} onClick={setSidebarIsShown} />
            </div>
            <ul>
                {subpages.map((subpage) => (
                    <li key={subpage.name} onClick={setSidebarIsShown}>
                        <NavLink to={subpage.path}>{subpage.name}</NavLink>
                    </li>
                ))}
            </ul>
        </nav>
    );
}