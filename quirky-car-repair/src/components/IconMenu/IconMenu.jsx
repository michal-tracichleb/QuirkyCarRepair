import styles from "./IconMenu.module.css"
import {Link} from "react-router-dom";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faUser} from "@fortawesome/free-regular-svg-icons";
import {faShoppingBasket} from "@fortawesome/free-solid-svg-icons";

export function IconMenu(){
    const cartItems = 2;
    return(
        <ul className={styles.iconMenu}>
            <li>
                <Link to="/userPanel"><FontAwesomeIcon icon={faUser}/></Link>
            </li>
            <li>
                <Link to="/cart">
                    <FontAwesomeIcon icon={faShoppingBasket}/>
                    <div className={styles.numberOfProducts}>{cartItems}</div>
                </Link>
            </li>
        </ul>
    )
}