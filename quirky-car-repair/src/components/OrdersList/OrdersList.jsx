import styles from "./OrdersList.module.css"
import {Link} from "react-router-dom";
import {dateFormatter} from "../../utlis/dateFormatter.js";
export function OrdersList({ordersList}){

    return(
        <div className={styles.container}>
            {ordersList && ordersList.map((order) =>(
                <Link key={order.id} to={`details/${order.id}`}>
                    <div className={styles.orderContainer}>
                        <div className={styles.order}>
                            <h3>Numer dokumentu: {order.documentNumber}</h3>
                            <p>Typ: {order.type}</p>
                            <p>Data: {dateFormatter(order.transactionDate)}</p>
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