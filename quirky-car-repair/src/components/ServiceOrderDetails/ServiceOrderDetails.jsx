import styles from "./ServiceOrderDetails.module.css"
import {useContext, useEffect, useState} from "react";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import {dateFormatter} from "../../utlis/dateFormatter.js";
import {UserStateContext} from "../../context/UserStateContext.js";
import {ServiceOptionsPicker} from "../ServiceOptionsPicker/ServiceOptionsPicker.jsx";
import {useLoaderData} from "react-router-dom";
import {ProductManageLink} from "../ProductManageLink/ProductManageLink.jsx";
import {serviceOrderCanceled} from "../../api/serviceOrderStatusManagement/serviceOrderCanceled.js";
import {orderStatus} from "../../constans/serviceEnums.js";
import {serviceOrderAcceptedDate} from "../../api/serviceOrderStatusManagement/serviceOrderAcceptedDate.js";
import {serviceOrderRepairAnalysis} from "../../api/serviceOrderStatusManagement/serviceOrderRepairAnalysis.js";
import {serviceOrderCanceledByClient} from "../../api/serviceOrderStatusManagement/serviceOrderCanceledByclient.js";
import {serviceOrderRepair} from "../../api/serviceOrderStatusManagement/serviceOrderRepair.js";
import {serviceOrderReady} from "../../api/serviceOrderStatusManagement/serviceOrderReady.js";
import {serviceOrderComplaint} from "../../api/serviceOrderStatusManagement/serviceOrderComplaint.js";
import {serviceOrderPendingForClientAccepting} from "../../api/serviceOrderStatusManagement/serviceOrderPendingForClientAccepting.js";
import {serviceOrderAcceptedByClient} from "../../api/serviceOrderStatusManagement/serviceOrderAcceptedByClient.js";


export function ServiceOrderDetails(){
    const response = useLoaderData();
    const [,setAlert] = useContext(AlertStateContext);
    const [user] = useContext(UserStateContext);

    const [orderDetails, setOrderDetails] = useState([]);
    const [vehicleData, setVehicleData] = useState([]);
    const [userData, setUserData] = useState([]);
    const [orderedParts, setOrderedParts] = useState();
    const [services, setServices] = useState();

    const managementPermissions = user.role.toLocaleLowerCase() === 'admin' || user.role.toLocaleLowerCase() === 'mechanic';

    useEffect(() => {
        if(response.success){
            setOrderDetails(response.data);
            setVehicleData(response.data.vehicleData);
            setUserData(response.data.userData);
            setOrderedParts(response.data.orderedParts);
            setServices(response.data.services);
        }else{
            Error({text: response.message, color: 'warning'})
        }

    }, []);
    const updateOrderStatus = async (e) =>{
        let cancel = e.target.name === 'cancel';
        let response;
        switch (orderStatus[orderDetails.status]){
            case 0:
                if(cancel){
                    response = await serviceOrderCanceled(orderDetails.serviceOrderId, '');
                }else{
                    response = await serviceOrderAcceptedDate(orderDetails.serviceOrderId, '');
                }
                break;
            case 8:
                response = await serviceOrderComplaint(orderDetails.serviceOrderId, '');
                break;
            case 9:
                response = await serviceOrderRepairAnalysis(orderDetails.serviceOrderId, '');
                break;
            case 10:
                response = await serviceOrderPendingForClientAccepting(orderDetails.serviceOrderId, '');
                break;
            case 11:
                if(cancel){
                    response = await serviceOrderCanceledByClient(orderDetails.serviceOrderId, '');
                }else{
                    response = await serviceOrderAcceptedByClient(orderDetails.serviceOrderId, '');
                }
                break;
            case 7:
            case 12:
                response = await serviceOrderRepair(orderDetails.serviceOrderId, 'asd');
                break;
            case 14:
                response = await serviceOrderReady(orderDetails.serviceOrderId, '');
                break;
        }

        if(response.success){
            setOrderDetails(response.data);
            setVehicleData(response.data.vehicleData);
            setUserData(response.data.userData);
            setOrderedParts(response.data.orderedParts);
            setServices(response.data.services);
        }else{
            Error({text: response.message, color: 'warning'})
        }
    }

    const Error = ({text, color}) =>{
        setAlert({text: text, color: color})
        setTimeout(() => {
            setAlert();
        }, 3000);
    }
    return (
        <div className={styles.container}>
            {orderDetails &&
                <>
                    <div className={styles.header}>
                        <div>
                            <h2>Numer zamówienia: {orderDetails.documentNumber}</h2>
                            <p>Data złożenia: {dateFormatter(orderDetails.dateStartRepair)}</p>
                        </div>
                        <div className={styles.toolbox}>
                            <h3>Status: {orderDetails.status}</h3>
                            <p>Data statusu: {dateFormatter(orderDetails.statusStartDate)}</p>

                            {(orderStatus[orderDetails.status] === 0 || orderStatus[orderDetails.status] === 11) &&
                                <>
                                    <button type="button" name="accept" className={styles.btn} onClick={updateOrderStatus}>Zaakceptuj</button>
                                    <button type="button" name="cancel" className={styles.cancel} onClick={updateOrderStatus}>Anuluj</button>
                                </>
                            }
                            {(user && user.role.toLocaleLowerCase() === 'user') &&  orderStatus[orderDetails.status] === 8 &&
                                <button type="button" className={styles.btn} onClick={updateOrderStatus}>Reklamacja</button>
                            }

                            {managementPermissions &&
                                <>
                                    {orderStatus[orderDetails.status] === 9 &&
                                        <button type="button" className={styles.btn} onClick={updateOrderStatus}>Diagnoza pojazdu</button>
                                    }
                                    {orderStatus[orderDetails.status] === 10 &&
                                        <button type="button" className={styles.btn} onClick={updateOrderStatus}>Zakończ diagnoze</button>
                                    }
                                    {(orderStatus[orderDetails.status] === 7 || orderStatus[orderDetails.status] === 12) &&
                                        <button type="button" className={styles.btn} onClick={updateOrderStatus}>Rozpocznij naprawe</button>
                                    }
                                    {orderStatus[orderDetails.status] === 14 &&
                                        <button type="button" className={styles.btn} onClick={updateOrderStatus}>Zakończ naprawę</button>
                                    }
                                </>
                            }
                        </div>
                    </div>
                    <div className={styles.details}>
                        <div>
                            <h3>Informacje od klienta:</h3>
                            {orderDetails.orderDescription}
                        </div>
                        <table className={styles.basicDetails}>
                            <thead>
                            <tr>
                                <th colSpan="2">Informacje podstawowe</th>
                            </tr>
                            </thead>
                            <tbody>
                            <tr>
                                <td>
                                    <div className={styles.row}>
                                        <div>
                                            <p>{vehicleData.brand} {vehicleData.model}</p>
                                            <p>Nr rejestracyjny: {vehicleData.plateNumber}</p>
                                        </div>
                                        <div>
                                            <p>Rok prod.: {vehicleData.year}</p>
                                            <p>VIN: {vehicleData.vin}</p>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <p>Klient: {userData.firstName} {userData.lastName}</p>
                                    <p>Nr tel.: {userData.phoneNumber}</p>
                                </td>
                            </tr>
                            </tbody>
                        </table>

                        <table className={styles.orderTable}>
                            <thead>
                            <tr>
                                <th colSpan="4">Usługi</th>
                            </tr>
                            <tr>
                                <th>Czynność</th>
                                <th>Cena</th>
                                <th>Ilość</th>
                                <th>Wartość</th>
                            </tr>
                            </thead>
                            <tbody>
                            {services && services.map((service) => (
                                <tr key={service.name}>
                                    <td>{service.name}</td>
                                    <td className={styles.right}>{service.unitPrice}</td>
                                    <td className={styles.right}>{service.quantity} szt.</td>
                                    <td className={styles.right}>{service.totalPrice}</td>
                                </tr>
                            ))}
                            </tbody>
                        </table>
                        {managementPermissions && /*i stan naprawy*/
                            <ServiceOptionsPicker/>
                        }
                        <table className={styles.orderTable}>
                            <thead>
                            <tr>
                                <th colSpan="4">Materiały</th>
                            </tr>
                            <tr>
                                <th>Nazwa</th>
                                <th>Cena</th>
                                <th>Ilość</th>
                                <th>Wartość</th>
                            </tr>
                            </thead>
                            <tbody>
                            {orderedParts && orderedParts.map((part) => (
                                <tr key={part.partId}>
                                    <td>{part.name}</td>
                                    <td className={styles.right}>{part.unitPrice}</td>
                                    <td className={styles.right}>{part.quantity} szt.</td>
                                    <td className={styles.right}>{part.totalPrice}</td>
                                </tr>
                            ))}
                            </tbody>
                        </table>
                        {managementPermissions &&
                            <div className={styles.toolbox}>
                                <ProductManageLink to="/warehouse">Zamów części</ProductManageLink>
                            </div>
                        }
                    </div>
                </>
            }
        </div>
    );
}