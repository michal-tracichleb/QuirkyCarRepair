import styles from "./ProductsList.module.css";
import {AddProductToCart} from "../../../utlis/AddProductToCart.js";
import {Link} from "react-router-dom";
import {useContext} from "react";
import {UserStateContext} from "../../../context/UserStateContext.js";
import {ProductQuantity} from "../../ProductQuantity/ProductQuantity.jsx";
import {ProductManageBox} from "../../ProductManageBox/ProductManageBox.jsx";
import {Button} from "../../Button/Button.jsx";

export function ProductsList({productsData, removeAction}){
    const [userData] = useContext(UserStateContext);
    const managementPermissions = userData.role.toLocaleLowerCase() === 'admin' || userData.role.toLocaleLowerCase() === 'storekeeper';

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
                                    {managementPermissions &&
                                        <ProductQuantity quantity={product.quantity} minimumQuantity={product.minimumQuantity}/>
                                    }
                                </div>
                            </Link>
                        </div>
                    <div className={styles.toolbox}>
                        <h3 className={styles.price}>{product.unitPrice} zł /szt.</h3>
                        <Button color="orange" width="w10" onClick={()=> {
                            AddProductToCart(product.id, product.name, product.unitPrice);
                        }}>Dodaj do koszyka</Button>
                        {managementPermissions &&
                            <ProductManageBox productId={product.id} removeFunction={removeAction}/>
                        }
                    </div>
                </div>
            ))}
        </div>

    )
}