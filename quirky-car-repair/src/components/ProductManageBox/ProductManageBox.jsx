import styles from "./ProductManageBox.module.css"
import {ProductManageLink} from "../ProductManageLink/ProductManageLink.jsx";
export function ProductManageBox({productId, removeFunction}){

    return(
        <div className={styles.box}>
            <ProductManageLink to={`/warehouse/product/manage?id=${productId}`}>Edytuj</ProductManageLink>
            <ProductManageLink onClick={()=>removeFunction(productId)}>Usuń</ProductManageLink>
        </div>
    )
}
