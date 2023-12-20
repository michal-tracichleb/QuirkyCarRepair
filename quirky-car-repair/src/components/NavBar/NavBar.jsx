import logo from "../../assets/Logo_1.jpg"
import styles from "./NavBar.module.css"
import {UserDropDownMenu} from "../UserDropDownMenu.jsx";
import {NavLink} from "react-router-dom";
import {CartDropDownMenu} from "../CartDropDownMenu/CartDropDownMenu.jsx";

export function NavBar({userIsLogged, userData, setUserIsLogged}){
    const handleUserLogout=()=>{
        sessionStorage.removeItem('user')
        setUserIsLogged(false);
    }

    return(
        <>
            <div id="navbar">
                <nav className="navbar navbar-dark bg-dark navbar-expand-md">
                    <button className="navbar-toggler" type="button" data-bs-toggle="offcanvas" data-bs-target="#navbarOffcanvasLg" aria-controls="navbarOffcanvasLg" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>

                    <NavLink className="navbar-brand" to={"/"}>
                        <img src={logo} alt="logo" className={styles.logo}/>
                        Quirky Car Repair
                    </NavLink>
                    <div className={`offcanvas offcanvas-start text-bg-dark ${styles.sidebar}`} tabIndex="-1" id="navbarOffcanvasLg" aria-labelledby="navbarOffcanvasLgLabel">
                        <div className="offcanvas-header">
                            <h5 className="offcanvas-title" id="offcanvasExampleLabel">Menu</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                        </div>
                        <div className="offcanvas-body">
                            <ul className="navbar-nav me-auto">
                                <li className="nav-item">
                                    <NavLink className="nav-link" to="/warehouse" >Magazyn</NavLink>
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
                        </div>
                    </div>
                    <div className="row align-items-end">
                        <div className="col">

                            {!userIsLogged ?
                                <a className={styles.login_link} href="#" data-bs-toggle="modal" data-bs-target="#logInModal">Zaloguj się</a>
                                :
                                <UserDropDownMenu handleUserLogout={handleUserLogout}/>
                            }
                        </div>
                        <div className="col">
                            <CartDropDownMenu />
                        </div>
                    </div>

                </nav>
            </div>
        </>
    )
}