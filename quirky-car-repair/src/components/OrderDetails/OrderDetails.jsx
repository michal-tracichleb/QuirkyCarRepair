import styles from "./OrderDetails.module.css"
import {useLoaderData} from "react-router-dom";
import {useContext, useEffect, useState} from "react";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import {dateFormatter} from "../../utlis/dateFormatter.js";
import {UserStateContext} from "../../context/UserStateContext.js";
import {cancelOrder} from "../../api/cancelOrder.js";
import {arrangeOrder} from "../../api/arrangeOrder.js";
import {readyForPickup} from "../../api/readyForPickup.js";
import {orderCompleted} from "../../api/orderCompleted.js";
export function OrderDetails(){
    const response = useLoaderData();
    const [,setAlert] = useContext(AlertStateContext);
    const [userData] = useContext(UserStateContext);

    const [orderDetails, setOrderDetails] = useState();
    const [, setPackedProducts] = useState([]);
    const [orderIsReady, setOrderIsReady] = useState(false);

    const managementPermissions = userData.role.toLocaleLowerCase() === 'admin' || userData.role.toLocaleLowerCase() === 'storekeeper';

    useEffect(() => {
        if(response.success){
            setOrderDetails(response.data);
        }else{
            setAlert({text: response.message, color: 'warning'});

            setTimeout(() => {
                setAlert();
            }, 3000);
        }
    }, []);
    const cancelOrderOnClick = async () =>{
        const userConfirmed = window.confirm('Czy na pewno chcesz anulować to zlecenie?');

        if(userConfirmed) {
            const response = await cancelOrder(orderDetails.operationalDocumentId);
            setAlert({text: response.message, color: response.success ? 'success' : 'warning'});
            setTimeout(() => {
                setAlert();
            }, 3000);
        }
    }
    const arrangeOrderOnClick = async () =>{
            const response = await arrangeOrder(orderDetails.operationalDocumentId);
            setAlert({text: response.message, color: response.success ? 'success' : 'warning'});
            setTimeout(() => {
                setAlert();
                window.location.reload();
            }, 3000);
    }
    const readyForPickupOnClick = async () =>{
        const response = await readyForPickup(orderDetails.operationalDocumentId);
        setAlert({text: response.message, color: response.success ? 'success' : 'warning'});
        setTimeout(() => {
            setAlert();
            window.location.reload();
        }, 3000);
    }
    const orderCompletedupOnClick = async () =>{
        const response = await orderCompleted(orderDetails.operationalDocumentId);
        setAlert({text: response.message, color: response.success ? 'success' : 'warning'});
        setTimeout(() => {
            setAlert();
            window.location.reload();
        }, 3000);
    }
    const updatePackedProducts = (productId, isChecked) => {
        setPackedProducts((prevState) => {
            const index = prevState.findIndex((product) => product.id === productId);

            if (index !== -1) {
                const updatedProducts = prevState.map((product) =>
                    product.id === productId ? { ...product, isChecked } : product
                );
                updateOrderIsReady(updatedProducts);
                return updatedProducts;
            } else {
                const newProduct = { id: productId, isChecked };
                const updatedProducts = [...prevState, newProduct];
                updateOrderIsReady(updatedProducts);
                return updatedProducts;
            }
        });
    };
    const updateOrderIsReady = (updatedProducts) => {
        const allProductsPacked = updatedProducts.every((product) => product.isChecked);
        if (allProductsPacked && orderDetails.orderedParts.length === updatedProducts.length) {
            setOrderIsReady(true);
        } else {
            setOrderIsReady(false);
        }
    };
    return(
        <div className={styles.container}>
            {orderDetails &&
                <>
                    <div className={styles.header}>
                        <div>
                            <h2>Numer zamówienia: {orderDetails.documentNumber}</h2>
                            <p>Data złożenia: {dateFormatter(orderDetails.transactionStartDate)}</p>
                            <p>Typ: {orderDetails.type}</p>
                        </div>
                        <div className={styles.toolbox}>
                            <h3>Status: {orderDetails.status}</h3>
                            <p>Data statusu: {dateFormatter(orderDetails.statusStartDate)}</p>
                            {managementPermissions &&
                                <>
                                    {orderDetails.status.toLowerCase() === "pending" &&
                                        <>
                                            <button type="button" className={styles.btn} onClick={arrangeOrderOnClick}>Przyjmij zamówienie</button>
                                            <button type="button" className={styles.cancel} onClick={cancelOrderOnClick}>Anuluj</button>
                                        </>
                                    }
                                    {orderDetails.status.toLowerCase() === "arrangeorder" &&
                                        <button type="button" className={styles.btn} disabled={!orderIsReady} onClick={readyForPickupOnClick}>Gotowe do odbioru</button>
                                    }
                                    {orderDetails.status.toLowerCase() === "readyforpickup" &&
                                        <button type="button" className={styles.btn} onClick={orderCompletedupOnClick}>Zamówienie wydane</button>
                                    }
                                </>
                            }
                        </div>
                    </div>
                    <div className={styles.details}>
                        {orderDetails.description &&
                            <div>
                                <h4>Opis produktu:</h4>
                                {orderDetails.description}
                            </div>
                        }
                        <h4>Lista produktów</h4>
                        {orderDetails.orderedParts && orderDetails.orderedParts.map((part) => (
                            <div key={part.partId} className={styles.product}>
                                <div>
                                    <h4>{part.name}</h4>
                                    <table className={styles.detailsTable}>
                                        <thead>
                                        <tr>
                                            <th>Cena</th>
                                            {managementPermissions &&
                                                <th>Marża</th>
                                            }
                                            <th>Ilość</th>
                                        </tr>
                                        </thead>
                                        <tbody>
                                        <tr key={part.partId}>
                                            <td>{part.unitPrice}</td>
                                            {managementPermissions &&
                                                <td>{part.marginValue}</td>
                                            }
                                            <td>{part.quantity} ({part.unitType})</td>
                                        </tr>
                                        </tbody>
                                    </table>
                                </div>
                                {managementPermissions && orderDetails.status.toLowerCase() === "arrangeorder" &&
                                    <div className={styles.packing}>
                                        <label htmlFor="packed">Spakowane</label>
                                        <input type="checkbox" name="packed" onChange={(e)=>updatePackedProducts(part.partId, e.target.checked)}/>
                                    </div>
                                }
                            </div>
                        ))}
                    </div>
                </>
            }
        </div>
    )
}