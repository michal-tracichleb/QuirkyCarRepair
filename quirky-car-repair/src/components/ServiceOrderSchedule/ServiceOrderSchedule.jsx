import {useSearchParams} from "react-router-dom";
import {useContext, useEffect, useRef, useState} from "react";
import { format, addDays, subDays } from 'date-fns';
import {AlertStateContext} from "../../context/AlertStateContext.js";
import styles from "./ServiceOrderSchedule.module.css";
import {Pagination} from "../Pagination/Pagination.jsx";
import {getServiceOrderPage} from "../../api/getServiceOrderPage.js";
import {ServiceOrdersList} from "../ServiceOrdersList/ServiceOrdersList.jsx";
import {orderStatus} from "../../constans/serviceEnums.js";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faAngleLeft, faAngleRight} from "@fortawesome/free-solid-svg-icons";

export function ServiceOrderSchedule(){
    const [searchParams] = useSearchParams();
    const pageId = searchParams.get('page');

    const [,setAlert] = useContext(AlertStateContext);

    const [serviceOrdersData, setServiceOrdersData] = useState([]);
    const [selectedDate, setSelectedDate] = useState(new Date());
    const scroll = useRef();

    useEffect(() => {
        fetchData();
        if (scroll.current) {
            scroll.current.scrollIntoView({behavior: 'smooth'});
        }
    }, [pageId, selectedDate]);

    const handlePrevDay = () => {
        setSelectedDate(subDays(selectedDate, 1));
    };
    const handleNextDay = () => {
        setSelectedDate(addDays(selectedDate, 1));
    };

    const fetchData = async () =>{
        const orderStatuses = Object.values(orderStatus).filter(status => status !== orderStatus.Pending && status !== orderStatus.Canceled);

        const body = {page: pageId, pageSize: 10, anyDate: false, orderStates: orderStatuses, fromDate: format(selectedDate, 'yyyy-MM-dd'), toDate: format(selectedDate, 'yyyy-MM-dd')}
        const response = await getServiceOrderPage(body);
        if(response.success){
            setServiceOrdersData(response.data);
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

    return(
        <>
            <div ref={scroll}></div>
            <div className={styles.toolbox}>
                <button onClick={handlePrevDay} className={styles.arrow}><FontAwesomeIcon icon={faAngleLeft}/></button>
                    <span>{format(selectedDate, 'dd.MM.yyyy')}</span>
                <button onClick={handleNextDay} className={styles.arrow}><FontAwesomeIcon icon={faAngleRight} /></button>
            </div>


            <ServiceOrdersList ordersList={serviceOrdersData.items}/>

            <Pagination pageId={pageId} pageCount={serviceOrdersData.pageCount} path={`/service/orders`}/>
        </>
    )
}