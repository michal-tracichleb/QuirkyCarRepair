import styles from "./ServiceOrdersList.module.css"
import {Link} from "react-router-dom";
import {dateFormatter} from "../../utlis/dateFormatter.js";
export function ServiceOrdersList({ordersList}){
    return(
        <div className={styles.container}>
            {ordersList && ordersList.map((order) =>(
                <Link key={order.serviceOrderId} to={`details/${order.id}`}>
                    <div className={styles.orderContainer}>
                        <div className={styles.order}>
                            <h3>Numer dokumentu: {order.documentNumber}</h3>
                            <p>Data statusu: {dateFormatter(order.statusStartDate)}</p>
                            <p>Proponowana data naprawy: {dateFormatter(order.dateStartRepair)}</p>
                            <p>Pojazd: {order.vehicleData.brand} {order.vehicleData.model} {order.vehicleData.year}r.</p>
                        </div>
                        <div className={styles.status}>
                            <span>Status: <h3>{order.status}</h3></span>
                        </div>
                    </div>
                </Link>
            ))}
        </div>
    )
}