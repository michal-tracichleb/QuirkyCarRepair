import logo from './images/Logo_1.bmp'
function NavBar() {
    return(
        <div id="navbar">
            <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                <div className="container-fluid">
                    <img src={logo} alt="" width="40" height="40" className="d-inline-block align-text-top" />
                    <a className="navbar-brand" href="#">
                            Quirky Car Repair
                    </a>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarNav">
                        <ul className="navbar-nav me-auto">
                            <li className="nav-item">
                                <a className="nav-link" href="#">Magazyn</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="#">Serwis</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="#">O nas</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="#">Kontakt</a>
                            </li>
                        </ul>

                        <span className="navbar-text">
                            <a className="nav-link active" href="#">Logowanie</a>
                        </span>

                    </div>
                </div>
            </nav>
        </div>
    );
}
export default NavBar;