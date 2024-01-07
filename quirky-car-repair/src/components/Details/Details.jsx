import styles from "./Details.module.css"
import {AddProductToCart} from "../../utlis/AddProductToCart.js";
import {useContext} from "react";
import {UserStateContext} from "../../context/UserStateContext.js";
import {ProductQuantity} from "../ProductQuantity/ProductQuantity.jsx";
import {ProductManageBox} from "../ProductManageBox/ProductManageBox.jsx";
import {useNavigate} from "react-router-dom";
import {removeProduct} from "../../api/removeProduct.js";
import {AlertStateContext} from "../../context/AlertStateContext.js";
export function Details({product}){
    const [userData] = useContext(UserStateContext);
    const [,setAlert] = useContext(AlertStateContext);
    const managementPermissions = userData.role.toLocaleLowerCase() === 'admin' || userData.role.toLocaleLowerCase() === 'storekeeper';
    const navigate = useNavigate();
    const lengthUnit=" mm.";
    const weightUnit=" kg.";

    const HandleRemoveProduct = async  (id) =>{
        const userConfirmed = window.confirm('Czy na pewno chcesz usunąć ten produkt?');

        if(userConfirmed) {
            const response = await removeProduct(id);
            if(response.success){
                setAlert({text: response.message, color: 'success'});

                navigate(-1)
            }else{
                setAlert({text: response.message, color: 'warning'});
            }
            setTimeout(() => {
                setAlert();
            }, 3000);
        }
    }


    return(
        <>
            <div className={styles.details}>
                <h2>{product.name}</h2>
                <p>{product.manufacturer}</p>
                {managementPermissions &&
                    <ProductQuantity quantity={product.quantity} minimumQuantity={product.minimumQuantity}/>
                }
            </div>
            <div className={styles.toolbox}>
                <p className={styles.price}>{product.unitPrice}zł</p>
                {managementPermissions &&
                    <ProductManageBox productId={product.id} removeFunction={HandleRemoveProduct}/>
                }
                {!managementPermissions &&
                    <button className={styles.btn} onClick={()=> {
                        AddProductToCart(product.id, product.name, product.unitPrice);
                    }}>Dodaj do koszyka</button>
                }
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
