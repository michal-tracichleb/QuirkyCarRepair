import logo from "../../assets/Logo_1.jpg"
import styles from "./NavBar.module.css"
import {UserDropDownMenu} from "../UserDropDownMenu.jsx";
import {NavLink} from "react-router-dom";
export function NavBar({userIsLogged, userData, setUserIsLogged}){
    const handleUserLogout=()=>{
        sessionStorage.removeItem('user')
        setUserIsLogged(false);
    }

    return(
        <>
            <div id="navbar">
                <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                    <div className="container-fluid">
                        <img src={logo} alt="logo" className={styles.logo}/>
                        <NavLink className="navbar-brand" to={"/"}>
                            Quirky Car Repair
                        </NavLink>
                        <button className="navbar-toggler" type="button" data-bs-toggle="collapse"
                                data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false"
                                aria-label="Toggle navigation">
                            <span className="navbar-toggler-icon"></span>
                        </button>
                        <div className="collapse navbar-collapse col" id="navbarNav">
                            <ul className="navbar-nav me-auto">
                                <li className="nav-item">
                                    <NavLink className="nav-link" to="/warehouse">Magazyn</NavLink>
                                </li>
                                <li className="nav-item">
                                    <NavLink className="nav-link" to="/serwis">Serwis</NavLink>
                                </li>
                                <li className="nav-item">
                                    <NavLink className="nav-link" to="/about">O Nas</NavLink>
                                </li>
                                <li className="nav-item">
                                    <NavLink className="nav-link" to="/contact">Kontakt</NavLink>
                                </li>
                            </ul>
                            <div className={`col ${styles.user_panel}`} >
                                {!userIsLogged ?
                                    <a className={styles.login_link} href="#" data-bs-toggle="modal" data-bs-target="#logInModal">Logowanie</a>
                                    :
                                    <UserDropDownMenu userName={userData.userName} handleUserLogout={handleUserLogout}/>
                                }
                            </div>
                        </div>
                    </div>
                </nav>
            </div>
        </>
    )
}