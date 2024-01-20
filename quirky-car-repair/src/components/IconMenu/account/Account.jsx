import styles from "./Account.module.css"
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faUser} from "@fortawesome/free-regular-svg-icons";
import {DropdownList} from "../../DropdownList/DropdownList.jsx";
import {Link, useNavigate} from "react-router-dom";
import {useContext} from "react";
import {UserStateContext} from "../../../context/UserStateContext.js";
import {Button} from "../../Button/Button.jsx";

export function Account(){
    const navigate = useNavigate();
    const [userData, setUserData] = useContext(UserStateContext);
    const userIsLogged = userData && userData.id;
    const handleUserLogout=()=>{
        setUserData([]);
        sessionStorage.removeItem('user');
        sessionStorage.removeItem('cart');
        navigate('/');
    }

    const notSignedInContent=(
        <ul>
            <li>
                <h3>Masz już konto?</h3>
                <Button color="orange" width="w100"><Link to="/authentication?mode=signin">Zaloguj się</Link></Button>
            </li>
            <li>
                <h3>Jesteś tutaj pierwszy raz?</h3>
                <Button color="grey" width="w100"><Link to="/authentication?mode=singup">Zarejestruj się</Link></Button>
            </li>
        </ul>
    );
    const signedInContent=(
        <ul>
            <li>
                <Link to={`user/details/${userData.id}`}>Twoje dane</Link>
            </li>
            {userData && userData.token && userData.role.toLowerCase() === 'user' &&
                <li>
                    <Link to={`user/service/orders?page=1`}>Zlecenia serwisowe</Link>
                </li>
            }
            <li>
                <Button color="grey" onClick={handleUserLogout} width="w100">Wyloguj się</Button>
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