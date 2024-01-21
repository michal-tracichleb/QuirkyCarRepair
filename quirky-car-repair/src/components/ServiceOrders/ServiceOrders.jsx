import {useNavigate, useSearchParams} from "react-router-dom";
import {useContext, useEffect, useRef, useState} from "react";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import styles from "./ServiceOrders.module.css";
import {orderStatus} from "../../constans/serviceEnums.js";
import {PaginationSmall} from "../PaginationSmall/PaginationSmall.jsx";
import {Pagination} from "../Pagination/Pagination.jsx";
import {getServiceOrderPage} from "../../api/service/getServiceOrderPage.js";
import {ServiceOrdersList} from "../ServiceOrdersList/ServiceOrdersList.jsx";

export function ServiceOrders(){
    const navigate = useNavigate();
    const [searchParams] = useSearchParams();
    const pageId = searchParams.get('page');
    const transactionState = searchParams.get('state');

    const [,setAlert] = useContext(AlertStateContext);

    const [serviceOrdersData, setServiceOrdersData] = useState([]);
    const [state, setState] = useState(transactionState);
    const scroll = useRef();

    useEffect(() => {
        updateUrl();
        fetchData();
        if (scroll.current) {
            scroll.current.scrollIntoView({behavior: 'smooth'});
        }
    }, [pageId, state]);
    const fetchData = async () =>{
        const orderState = state === '' ? [] : [Number(state)];
        const body = {page: pageId, pageSize: 10, anyDate: true, orderStates: orderState}
        const response = await getServiceOrderPage(body);
        if(response.success){
            setServiceOrdersData(response.data);
        }else{
            Error({text: response.message, color: 'warning'})
        }
    }
    const updateUrl = () => {
        navigate(`?page=${pageId}${state ? '&state='+state : ''}`)
    };
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
                <div className={styles.select}>
                    <label>Status zamówienia</label>
                    <select id="stateSelect" onChange={(e) => setState(e.target.value)} value={state ? state : ''}>
                        <option value=''>Wszystkie</option>
                        {Object.keys(orderStatus).map((stateName) => (
                            <option key={stateName} value={orderStatus[stateName]}>{stateName}</option>
                        ))}
                    </select>
                </div>
            </div>

            <PaginationSmall pageId={pageId} pageCount={serviceOrdersData.pageCount} path={`/service/orders`}/>

            <ServiceOrdersList ordersList={serviceOrdersData.items}/>

            <Pagination pageId={pageId} pageCount={serviceOrdersData.pageCount} path={`/service/orders`}/>
        </>
    )
}