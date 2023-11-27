import logo from "../../assets/Logo_1.jpg"
import styles from "./NavBar.module.css"
export function NavBar({userIsLogged, userData}){
    return(
        <>
            <div id="navbar">
                <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                    <div className="container-fluid">
                        <img src={logo} alt="logo" className={styles.logo}/>
                        <a className="navbar-brand" href="#">
                            Quirky Car Repair
                        </a>
                        <button className="navbar-toggler" type="button" data-bs-toggle="collapse"
                                data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false"
                                aria-label="Toggle navigation">
                            <span className="navbar-toggler-icon"></span>
                        </button>
                        <div className="collapse navbar-collapse col" id="navbarNav">
                            <ul className="navbar-nav me-auto">
                                <li className="nav-item">
                                    <a className="nav-link" href="#">Magazyn</a>
                                </li>
                                <li className="nav-item">
                                    <a className="nav-link" href="#">Serwis</a>
                                </li>
                                <li className="nav-item">
                                    <a className="nav-link" href="#">O Nas</a>
                                </li>
                                <li className="nav-item">
                                    <a className="nav-link" href="#">Kontakt</a>
                                </li>
                            </ul>
                            <div className="col text-end">
                                {!userIsLogged ?
                                    <a className={styles.login_link} href="#" data-bs-toggle="modal" data-bs-target="#logInModal">Logowanie</a>
                                    :
                                    <a className={styles.login_link} href="#">Witaj: {userData.userName}</a>
                                }
                            </div>
                        </div>
                    </div>
                </nav>
            </div>
        </>
    )
}