import styles from "./CartProductsList.module.css"
import {CenteredContent} from "../CenteredContent/CenteredContent.jsx";
import {removeCartItem} from "../../utlis/removeCartItem.js";
import {useState} from "react";
import {CartSummary} from "../CartSummary/CartSummary.jsx";
import {FlexContainer} from "../FlexContainer/FlexContainer.jsx";
import {getCartItems} from "../../utlis/getCartItems.js";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faXmark} from "@fortawesome/free-solid-svg-icons";
export function CartProductsList(){
    const [items, setItems] = useState(getCartItems());

    const handleRemoveCartItem = (id) =>{
        const response = removeCartItem(id)
        if(response.success){
            setItems(response.data);
            window.location.reload();
        }
    }
    return(
        <FlexContainer>
            <CenteredContent>
                <div className={styles.productsList}>
                    <h2>Produkty</h2>
                    <div>
                        {items && items.map((item) => {
                            return (
                                <div className={styles.product} key={item.id}>
                                    <div className={styles.productInfo}>
                                        <div className={styles.topRow}>
                                            <h3>{item.name}</h3>
                                            <p>Ilość: {item.quantity}</p>
                                        </div>
                                        <p className={styles.priceRow}>
                                            <span>Cena: {item.price} zł</span>
                                        </p>
                                        <div className={styles.buttonRow}>
                                            <button onClick={()=>handleRemoveCartItem(item.id)}>
                                                <FontAwesomeIcon icon={faXmark}/>
                                                Usuń
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            );
                        })}
                    </div>
                </div>
            </CenteredContent>
            <CartSummary cartItems={items}/>
        </FlexContainer>

    )
}