import React, {useState} from "react";

import logo from "../../img/Logo_1.bmp";
import LogInModal from "./LogInModal";
export default function NavBar({userIsLogged, setUserIsLogged, userData, setUserData}) {

    return (
        <>
            <div id="navbar">
                <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                    <div className="container-fluid">
                        <img src={logo} alt="" width="40" height="40" className="d-inline-block align-text-top"/>
                        <a className="navbar-brand" href="#">
                            Quirky Car Repair
                        </a>
                        <button className="navbar-toggler" type="button" data-bs-toggle="collapse"
                                data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false"
                                aria-label="Toggle navigation">
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
                                    <a className="nav-link" href="#">O Nas</a>
                                </li>
                                <li className="nav-item">
                                    <a className="nav-link" href="#">Kontakt</a>
                                </li>

                                {!userIsLogged ?
                                    <li className="nav-item">
                                        <a className="nav-link" href="#" data-bs-toggle="modal" data-bs-target="#logInModal">Logowanie</a>
                                    </li>
                                    :
                                    <li className="nav-item">
                                        //TODO: stworzyć panel usera
                                        <a className="nav-link" href="#">Witaj: </a>
                                    </li>
                                }
                            </ul>
                        </div>
                    </div>
                </nav>
            </div>
            {!userIsLogged &&
                <LogInModal
                    setUserIsLogged={setUserIsLogged}
                    setUserData={setUserData}
                />
            }
        </>
    );
}