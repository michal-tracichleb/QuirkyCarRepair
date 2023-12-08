import styles from "./ProductsList.module.css";
import {AddProductToCart} from "../../../utlis/AddProductToCart.js";

export function ProductsList({productsData}){
    return(
        <>
            {productsData && productsData.map((product)=> (
                <div className={`row ${styles.product}`} key={product.id}>
                    <div className="col-8">
                        <h3>{product.name}</h3>
                        <p className={styles.manufacturer}>Producent: {product.manufacturer}</p>
                        <p>Model: {product.model}</p>
                        <p className={styles.code}>Kod produktu: {product.productCode}</p>
                    </div>
                    <div className="col-4 border-start border-1 text-center ">
                        <h3 className={styles.price}>{product.unitPrice} zł /szt.</h3>
                        <button className={styles.btn} onClick={()=>AddProductToCart(product.id, product.name, product.unitPrice)}>Dodaj do koszyka</button>
                    </div>
                </div>
            ))}
        </>

    )
}