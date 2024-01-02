import styles from "./ProductsList.module.css";
import {AddProductToCart} from "../../../utlis/AddProductToCart.js";
import {Link} from "react-router-dom";

export function ProductsList({productsData}){

    return(
        <div className={styles.container}>
            {productsData && productsData.map((product)=>(
                <div className={styles.productContainer} key={product.id}>
                        <div className={styles.product}>
                            <Link to={`product/${product.id}`}>
                                <div>
                                    <h3>{product.name}</h3>
                                    <p className={styles.manufacturer}>Producent: {product.manufacturer}</p>
                                    <p>Model: {product.model}</p>
                                    <p className={styles.code}>Kod produktu: {product.productCode}</p>
                                    <div className={styles.quantity}>
                                        <h3>Ilość: <span className={`${(product.quantity === 0) ? styles.dangerous : (product.quantity < product.minimumQuantity) ? styles.warning : styles.success}`}>{product.quantity}</span></h3>
                                        {product.quantity === 0 &&
                                            <h3 className={styles.dangerous}>Brak na stanie</h3>
                                        }
                                    </div>
                                </div>
                            </Link>
                        </div>
                        <div className={styles.toolbox}>
                            <h3 className={styles.price}>{product.unitPrice} zł /szt.</h3>
                            <button className={styles.btn} onClick={()=> {
                                AddProductToCart(product.id, product.name, product.unitPrice);
                            }}>Dodaj do koszyka</button>
                        </div>
                </div>
            ))}
        </div>

    )
}