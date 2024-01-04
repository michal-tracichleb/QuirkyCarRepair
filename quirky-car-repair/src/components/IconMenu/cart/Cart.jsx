import styles from "./Cart.module.css"
import {DropdownList} from "../../DropdownList/DropdownList.jsx";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faShoppingBasket} from "@fortawesome/free-solid-svg-icons";
import {useEffect, useState} from "react";
import {getCartPrice} from "../../../utlis/getCartPrice.js";
export function Cart(){
    const [cartItems, setCartItems] = useState([]);
    const [cartPrice, setCartPrice] = useState(0);

    useEffect(() => {
        const handleStorageChange = () => {
            const storedCartItems = sessionStorage.getItem('cart');
            if (storedCartItems) {
                setCartItems(JSON.parse(storedCartItems));
                let price = getCartPrice(JSON.parse(storedCartItems));
                setCartPrice(price);
            }
        };

        window.addEventListener('storage', handleStorageChange);

        handleStorageChange();

        return () => {
            window.removeEventListener('storage', handleStorageChange);
        };
    }, []);

    const listItem = cartItems.map((product) =>{
        return(
            <li key={product.id} className={styles.item}>
                <p>{product.name}</p>
                <p>
                    <span className={styles.quantity}>{product.quantity} szt.</span>
                    <span className={styles.price}>{product.price} zł</span>
                </p>
            </li>
        )
    });
    const list = (
        <ul>
            {listItem}
            <li className={styles.summary}>
                {cartItems.length > 0 ?
                    <>
                        <p>
                            <span>Do zapłaty:</span>
                            <span>{cartPrice} zł</span>
                        </p>
                        <button>Przejdź do koszyka</button>
                    </>
                    :
                    <span>Twój koszyk jest pusty</span>
                }
            </li>
        </ul>
    )


    const icon = (
        <>
            <FontAwesomeIcon icon={faShoppingBasket}/>
            {cartItems.length > 0 && <div className={styles.numberOfProducts}>{cartItems.length}</div>}
        </>
    );

    return(
        <div className={styles.cart}>
            <DropdownList trigger={icon} list={list}/>
        </div>
    )
}