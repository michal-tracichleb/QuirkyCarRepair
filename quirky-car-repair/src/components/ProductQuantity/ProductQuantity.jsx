import styles from "./ProductQuantity.module.css";

export function ProductQuantity({quantity, minimumQuantity}){
    return(
        <div className={styles.quantity}>
            <h3>Ilość: <span className={`${(quantity === 0) ? styles.dangerous : (quantity < minimumQuantity) ? styles.warning : styles.success}`}>{quantity}</span></h3>
            {quantity === 0 &&
                <h3 className={styles.dangerous}>Brak na stanie</h3>
            }
        </div>
    )
}