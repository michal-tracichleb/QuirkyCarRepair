import styles from "./Account.module.css"
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faUser} from "@fortawesome/free-regular-svg-icons";
import {DropdownList} from "../../DropdownList/DropdownList.jsx";
import {Link, useNavigate} from "react-router-dom";
import {useContext} from "react";
import {UserStateContext} from "../../../context/UserStateContext.js";

export function Account(){
    const navigate = useNavigate();
    const [userData, setUserData] = useContext(UserStateContext);
    const userIsLogged = userData && userData.id;
    const handleUserLogout=()=>{
        setUserData([]);
        sessionStorage.removeItem('user');
        navigate('/');
    }

    const notSignedInContent=(
        <ul>
            <li>
                <h3>Masz już konto?</h3>
                <button className={styles.btnSignin}><Link to="/authentication?mode=signin">Zaloguj się</Link></button>

            </li>
            <li>
                <h3>Jesteś tutaj pierwszy raz?</h3>
                <button className={styles.btnSignup}><Link to="/authentication?mode=singup">Zarejestruj się</Link></button>
            </li>
        </ul>
    );
    const signedInContent=(
        <ul>
            <li>
                <a>Twój profil</a>
            </li>
            <li>
                <a>Zamówienia</a>
            </li>
            <li>
                <button onClick={handleUserLogout} className={styles.btnLogout}>Wyloguj się</button>
            </li>
        </ul>
    );
    const icon = (<FontAwesomeIcon icon={faUser} />);
    return(
        <div className={styles.account}>
            <DropdownList trigger={icon} list={userIsLogged ? signedInContent : notSignedInContent}/>
        </div>
    )
}