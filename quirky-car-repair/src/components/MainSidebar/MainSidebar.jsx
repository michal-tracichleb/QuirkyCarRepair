import styles from "./MainSidebar.module.css"
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faXmark} from "@fortawesome/free-solid-svg-icons";
import {NavLink} from "react-router-dom";
import {SUBPAGES} from "../../constans/subpages.js";
export function MainSidebar({ sidebarIsShown, setSidebarIsShown}) {
    return (
        <nav className={`${styles.navMenu} ${sidebarIsShown ? styles.active : ''}`}>
            <div className={styles.header}>
                <h1>Menu</h1>
                <FontAwesomeIcon icon={faXmark} onClick={setSidebarIsShown} />
            </div>
            <ul>
                {SUBPAGES.map((subpage) => (
                    <li key={subpage.name}>
                        <NavLink to={subpage.path}>{subpage.name}</NavLink>
                    </li>
                ))}
            </ul>
        </nav>
    );
}