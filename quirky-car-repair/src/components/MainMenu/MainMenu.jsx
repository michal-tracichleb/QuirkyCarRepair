import styles from "./MainMenu.module.css"
import {NavLink} from "react-router-dom";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faGripLines} from "@fortawesome/free-solid-svg-icons";
import {getSubpages} from "../../utlis/getSubpages.js";

export function MainMenu({setSidebarIsShown}){
    const subpages = getSubpages();
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
                {subpages && subpages.map((subpage)=>(
                    <li key={subpage.name}>
                        <NavLink to={subpage.path}>{subpage.name}</NavLink>
                    </li>
                ))}
            </ul>
        </>

    )
}