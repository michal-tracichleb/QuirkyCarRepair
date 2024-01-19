import styles from "./IconMenu.module.css"
import {Account} from "./account/Account.jsx";
import {Cart} from "./cart/Cart.jsx";
import {useContext} from "react";
import {UserStateContext} from "../../context/UserStateContext.js";

export function IconMenu(){
    const [user] = useContext(UserStateContext);
    return(
        <ul className={styles.iconMenu}>
            <li>
                <Account/>
            </li>
            {user && user.token && user.role.toLowerCase() !== 'user' &&
                <li>
                    <Cart/>
                </li>
            }
        </ul>

    )
}