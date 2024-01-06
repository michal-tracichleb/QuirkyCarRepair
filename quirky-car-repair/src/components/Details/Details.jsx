import styles from "./Details.module.css"
import {AddProductToCart} from "../../utlis/AddProductToCart.js";
export function Details({product}){
    const lengthUnit=" mm.";
    const weightUnit=" kg.";
    return(
        <>
            <div className={styles.details}>
                <h2>{product.name}</h2>
                <p>{product.manufacturer}</p>
                <div className={styles.quantity}>
                    <h3>Ilość: <span className={`${(product.quantity === 0) ? styles.dangerous : (product.quantity < product.minimumQuantity) ? styles.warning : styles.success}`}>{product.quantity}</span></h3>
                    {product.quantity === 0 &&
                        <h3 className={styles.dangerous}>Brak na stanie</h3>
                    }
                </div>
            </div>
            <div className={styles.toolbox}>
                <p className={styles.price}>{product.unitPrice}zł</p>
                <button className={styles.btn} onClick={()=> {
                    AddProductToCart(product.id, product.name, product.unitPrice);
                }}>Dodaj do koszyka</button>
            </div>
            <div className={styles.specyfication}>
                <div>
                    <h4>Opis produktu:</h4>
                    {product.description}
                </div>
                <table className={styles.productTable}>
                    <tbody>
                    <tr>
                        <td>Producent</td>
                        <td>{product.manufacturer ? product.manufacturer : "-"}</td>
                    </tr>
                    <tr>
                        <td>Model</td>
                        <td>{product.model ? product.model : "-"}</td>
                    </tr>
                    <tr>
                        <td>Kod produktu</td>
                        <td>{product.productCode ? product.productCode : "-"}</td>
                    </tr>
                    <tr>
                        <td>Kraj produkcji</td>
                        <td>{product.countryOfOrigin ? product.countryOfOrigin : "-"}</td>
                    </tr>
                    <tr>
                        <td>Wysokość</td>
                        <td>{product.height ? product.height + lengthUnit : "-"}</td>
                    </tr>
                    <tr>
                        <td>Szerokość</td>
                        <td>{product.width ? product.width + lengthUnit : "-"}</td>
                    </tr>
                    <tr>
                        <td>Głębokość</td>
                        <td>{product.depth ? product.depth + lengthUnit : "-"}</td>
                    </tr>
                    <tr>
                        <td>Waga</td>
                        <td>{product.weight ? product.weight + weightUnit : "-"}</td>
                    </tr>
                    </tbody>
                </table>
            </div>
        </>
    )
}
