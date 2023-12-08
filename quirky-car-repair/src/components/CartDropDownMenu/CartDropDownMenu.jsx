import styles from "./CartDropDownMenu.module.css"
import {faBasketShopping} from "@fortawesome/free-solid-svg-icons";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {useEffect, useState} from "react";
import {getCartPrice} from "../../utlis/getCartPrice.js";

export function CartDropDownMenu(){
    const [cart, setCart] = useState([]);
    const [cartPrice, setCartPrice] = useState(0);
    const handleShowList = () =>{
        const storedCart = sessionStorage.getItem('cart');

        if (storedCart) {
            setCart(JSON.parse(storedCart));
            let price = getCartPrice(JSON.parse(storedCart));
            setCartPrice(price);
        }
    }
    return(
        <div className="dropdown-center">
            <a className={`dropdown-toggle ${styles.cart}`} data-bs-toggle="dropdown" aria-expanded="false" onClick={handleShowList}>
                <FontAwesomeIcon icon={faBasketShopping} />
            </a>

            <ul className={`dropdown-menu dropdown-menu-lg-end ${styles.list}`}>
                {cart.map(product => (
                    <li key={product.id} className={styles.item}>
                        <p>{product.name}</p>
                        <p>
                            <span className={styles.quantity}>{product.quantity} szt.</span>
                            <span className={styles.price}>{product.price} zł</span>
                        </p>
                    </li>
                ))}
                <li className={styles.summary}>
                    {cart.length > 0 ?
                        <>
                            <p>
                                <span>Do zapłaty:</span>
                                <span className="float-end">{cartPrice} zł</span>
                            </p>
                            <button className="btn btn-success w-100">Przejdź do koszyka</button>
                        </>
                        :
                        <span>Twój koszyk jest pusty</span>
                    }
                </li>
            </ul>
        </div>
    )
}