import styles from "./NavBar/NavBar.module.css";

export function UserDropDownMenu({userName, handleUserLogout}){

    return(
        <div className="dropdown-center">
            <a className={`dropdown-toggle ${styles.login_link}`} href="#" data-bs-toggle="dropdown" aria-expanded="false">
                Witaj: {userName}
            </a>

            <ul className="dropdown-menu dropdown-menu-lg-end">
                <li><a className="dropdown-item" href="#">Twój profil</a></li>
                <li><hr className="dropdown-divider" /></li>
                <li><a className="dropdown-item" href="#" onClick={handleUserLogout}>Wyloguj</a></li>
            </ul>
        </div>
    )
}