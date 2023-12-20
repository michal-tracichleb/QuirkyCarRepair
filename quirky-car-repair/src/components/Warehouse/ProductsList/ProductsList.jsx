import styles from "./ProductsList.module.css";
import {AddProductToCart} from "../../../utlis/AddProductToCart.js";
import {useContext, useState} from "react";
import {ProductModal} from "../ProductModal/ProductModal.jsx";
import {AlertStateContext} from "../../../context/AlertStateContext.js";

export function ProductsList({productsData}){
const [product, setProduct] = useState({});
const [alert, setAlert] = useContext(AlertStateContext);

const productAddedAlert=()=>{
        setAlert({color:'success', text: 'Dodano produkt do koszyka'})
        setTimeout(() => {
            setAlert();
        }, 3000);
}

const handleSetProduct=(data)=>{
    setProduct(data);
}
    return(
        <>
            {productsData && productsData.map((product)=> (
                <div className={`row ${styles.product}`} key={product.id}>
                    <div className="col-8"  key={product.id} data-bs-toggle="modal" data-bs-target="#productModal" onClick={()=>handleSetProduct(product)}>
                        <h3>{product.name}</h3>
                        <p className={styles.manufacturer}>Producent: {product.manufacturer}</p>
                        <p>Model: {product.model}</p>
                        <p className={styles.code}>Kod produktu: {product.productCode}</p>
                    </div>
                    <div className="col-4 border-start border-1 text-center ">
                        <h3 className={styles.price}>{product.unitPrice} zł /szt.</h3>
                        <button className={styles.btn} onClick={()=> {
                            AddProductToCart(product.id, product.name, product.unitPrice);
                            productAddedAlert()
                        }}>Dodaj do koszyka</button>
                    </div>
                </div>
            ))}
            <ProductModal productData={product} Alert={productAddedAlert}/>
        </>

    )
}