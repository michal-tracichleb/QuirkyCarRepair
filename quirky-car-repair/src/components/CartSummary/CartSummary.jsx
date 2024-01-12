import styles from "./CartSummary.module.css"
import {getCartPrice} from "../../utlis/getCartPrice.js";
import {SearchBar} from "../SearchBar/SearchBar.jsx";
import {useContext, useEffect, useState} from "react";
import {UserStateContext} from "../../context/UserStateContext.js";
import {orderProducts} from "../../api/orderProducts.js";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import {getServiceOrderPage} from "../../api/getServiceOrderPage.js";
import {orderStatus} from "../../constans/serviceEnums.js";

export function CartSummary({cartItems}){
    const [user] = useContext(UserStateContext);
    const [,setAlert] = useContext(AlertStateContext);

    const [documentId, setDocumentId] = useState(null);
    const [documentType, setDocumentType] = useState('');
    const [orders, setOrders] = useState([]);

    const Totalprice = getCartPrice(cartItems);

    useEffect(() => {
        if (user && user.role !=="user") {
            fetchData();
        }
    }, []);

    const fetchData = async () =>{
        const orderStatuses = Object.values(orderStatus).filter(status => status !== orderStatus.Pending && status !== orderStatus.Canceled);
        const body = {page: 1, pageSize: 10000000, anyDate: true, orderStates: orderStatuses}
        const response = await getServiceOrderPage(body);
        if(response.success){
            setOrders(response.data);
        }else{
            Error({text: response.message, color: 'warning'})
        }
    }
    const onSubmit = async () =>{
        if(documentType==="WW" && documentId && cartItems.length > 0){
            const data ={};
            data.orderType = documentType;
            data.ServiceOrderId = Number(documentId);
            data.orderParts = cartItems;
            const response = await orderProducts(data);

            if(response.success){
                Error({text: response.message, color:'success'});
            }else{
                Error({text: response.message, color:'warning'})
            }
        }
    }
    const Error = ({text, color}) =>{
        setAlert({text: text, color: color});
        setTimeout(() => {
            setAlert();
        }, 3000);
    }

    return(
        <div className={styles.cartSummary}>
            <h2>Podsumowanie</h2>
            <div className={styles.cartRow}>
                <p>Wartość produktów: {Totalprice} zł</p>
                <p>
                </p>
            </div>
            {user && user.role !=="user" &&
                <>
                    <div className={styles.cartRow}>
                        <label htmlFor="documentType">Typ dokumentu</label>
                        <select name="documentType" onChange={(e)=>setDocumentType(e.target.value)} defaultValue={documentType}>
                            <option value="" disabled>Typ dokumentu</option>
                            <option value="WW">WW</option>
                            <option value="WZ">ZZ</option>
                        </select>
                    </div>
                    {documentType === "WW" &&
                        <div className={styles.cartRow}>
                            <SearchBar list={orders.items} itemToDisplay="documentNumber" callback={(id)=>setDocumentId(id)} value={documentId} returnValue="serviceOrderId"/>
                        </div>
                    }
                </>
            }
            <button type="submit" className={styles.btn} disabled={documentType !=="WW" || !documentId} onClick={onSubmit}>Złóż zamówienie</button>
        </div>
    )
}