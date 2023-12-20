import styles from "./NavBar/NavBar.module.css";
import {NavLink} from "react-router-dom";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faUser} from "@fortawesome/free-regular-svg-icons";

export function UserDropDownMenu({handleUserLogout}){

    return(
        <div className="dropdown-center">
            <a className={`dropdown-toggle ${styles.login_link}`} data-bs-toggle="dropdown" aria-expanded="false">
                <FontAwesomeIcon icon={faUser}></FontAwesomeIcon>
            </a>

            <ul className="dropdown-menu dropdown-menu-lg-end">
                <li><NavLink className="dropdown-item" to="/user_profile">Twój profil</NavLink></li>
                <li><hr className="dropdown-divider" /></li>
                <li><a className="dropdown-item" href="#" onClick={handleUserLogout}>Wyloguj</a></li>
            </ul>
        </div>
    )
}