import styles from "./CartSummary.module.css"
import {getCartPrice} from "../../utlis/getCartPrice.js";
import {SearchBar} from "../SearchBar/SearchBar.jsx";
import {useContext, useEffect, useState} from "react";
import {UserStateContext} from "../../context/UserStateContext.js";
import {orderProducts} from "../../api/warehouse/orderProducts.js";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import {getServiceOrderPage} from "../../api/service/getServiceOrderPage.js";
import {orderStatus} from "../../constans/serviceEnums.js";
import {Button} from "../Button/Button.jsx";

export function CartSummary({cartItems, setCartItems}){
    const [user] = useContext(UserStateContext);
    const [,setAlert] = useContext(AlertStateContext);

    const [documentId, setDocumentId] = useState(0);
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
        if(cartItems.length > 0){
            const data ={};
            data.orderType = documentType;
            data.ServiceOrderId = Number(documentId);
            data.orderParts = cartItems;
            const response = await orderProducts(data);

            if(response.success){
                Error({text: response.message, color:'success'});
                setCartItems([])
                sessionStorage.removeItem('cart');
            }else{
                Error({text: response.message, color:'warning'})
            }
        }
    }
    const onSelectValueChange = (e) => {
        const value = e.target.value;
        setDocumentType(value);
        if(value === 'WZ'){
            setDocumentId(0);
        }
    };

    const isButtonDisabled = () => {
        return !documentType || (cartItems.length < 1) || (documentType === "WW" && !documentId);
    };
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
                        <select name="documentType" onChange={onSelectValueChange} defaultValue={documentType}>
                            <option value="" disabled>Typ dokumentu</option>
                            <option value="WW">WW</option>
                            <option value="WZ">WZ</option>
                        </select>
                    </div>
                    {documentType === "WW" &&
                        <div className={styles.cartRow}>
                            <SearchBar list={orders.items} itemToDisplay="documentNumber" callback={(id)=>setDocumentId(id)} value={documentId} returnValue="serviceOrderId"/>
                        </div>
                    }
                </>
            }
            <Button type="submit" disabled={isButtonDisabled()} onClick={onSubmit} color="orange" width="w100">Złóż zamówienie</Button>
        </div>
    )
}