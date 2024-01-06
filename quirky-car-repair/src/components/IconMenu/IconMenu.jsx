import styles from "./IconMenu.module.css"
import {Account} from "./account/Account.jsx";
import {Cart} from "./cart/Cart.jsx";

export function IconMenu(){
    return(
        <ul className={styles.iconMenu}>
            <li>
                <Account/>
            </li>
            <li>
                <Cart/>
            </li>
        </ul>

    )
}