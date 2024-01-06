import styles from "./MainMenu.module.css"
import {NavLink} from "react-router-dom";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faGripLines} from "@fortawesome/free-solid-svg-icons";
import {SUBPAGES} from "../../constans/subpages.js";

export function MainMenu({setSidebarIsShown}){
    return(
        <>
            <div className={styles.menu}>
                <a onClick={setSidebarIsShown}>
                    <div>
                        <FontAwesomeIcon icon={faGripLines}/>
                    </div>
                    <div>
                        <span>Menu</span>
                    </div>
                </a>
            </div>

            <ul className={styles.mainMenu}>
                {SUBPAGES.map((subpage)=>(
                    <li key={subpage.name}>
                        <NavLink to={subpage.path}>{subpage.name}</NavLink>
                    </li>
                ))}
            </ul>
        </>

    )
}