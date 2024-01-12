import styles from "./ServiceOrderDetails.module.css"
import {useContext, useEffect, useState} from "react";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import {dateFormatter} from "../../utlis/dateFormatter.js";
import {UserStateContext} from "../../context/UserStateContext.js";
import {ServiceOptionsPicker} from "../ServiceOptionsPicker/ServiceOptionsPicker.jsx";
import {Link, useLoaderData} from "react-router-dom";
import {ProductManageLink} from "../ProductManageLink/ProductManageLink.jsx";

export function ServiceOrderDetails(){
    const response = useLoaderData();
    const [,setAlert] = useContext(AlertStateContext);
    const [user] = useContext(UserStateContext);

    const [orderDetails, setOrderDetails] = useState();
    const [vehicleData, setVehicleData] = useState();
    const [userData, setUserData] = useState();
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
                            {managementPermissions &&
                                <>
                                    {/*{orderDetails.status.toLowerCase() === "pending" &&
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
                                    }*/}
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
                        <div className={styles.toolbox}>
                            <Link className={styles.orderParts} to="/warehouse"></Link>
                            <ProductManageLink to="/warehouse">Zamów części</ProductManageLink>
                        </div>
                    </div>
                </>
            }
        </div>
    );
}