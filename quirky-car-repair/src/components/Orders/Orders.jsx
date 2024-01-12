import styles from "./Orders.module.css";
import {useNavigate, useSearchParams} from "react-router-dom";
import {useContext, useEffect, useRef, useState} from "react";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import {getOrdersPage} from "../../api/getOrdersPage.js";
import {PaginationSmall} from "../PaginationSmall/PaginationSmall.jsx";
import {Pagination} from "../Pagination/Pagination.jsx";
import {OrdersList} from "../OrdersList/OrdersList.jsx";
import {orderType, orderStatus} from "../../constans/warehouseEnums.js";

export function Orders(){
    const navigate = useNavigate();
    const [searchParams] = useSearchParams();
    const pageId = searchParams.get('page');
    const transactionType = searchParams.get('type');
    const transactionState = searchParams.get('state');

    const [,setAlert] = useContext(AlertStateContext);

    const [ordersData, setOrdersData] = useState([]);
    const [type, setType] = useState(transactionType);
    const [state, setState] = useState(transactionState);

    const scroll = useRef();

    useEffect(() => {
        fetchOrdersPage();
        updateUrl();
        if (scroll.current) {
            scroll.current.scrollIntoView({behavior: 'smooth'});
        }
    }, [pageId, type, state]);

    const fetchOrdersPage = async () => {
        const body = {};
        const pageSize = 10;
        body.page = pageId;
        body.pageSize = pageSize;

        if (type) {
            body.orderTypes = [Number(type)];
        }
        if (state){
            body.orderStates = [Number(state)];
        }

        const response = await getOrdersPage(body);

        if(response.success){
            setOrdersData(response.data);
        }else{
            setAlert({text: response.message, color: 'warning'});
            setTimeout(() => {
                setAlert();
            }, 3000);
        }
    };
    const updateUrl = () => {
        navigate(`?page=${pageId}${type ? '&type='+type : ''}${state ? '&state='+state : ''}`)
    };

    return(
        <>
            <div ref={scroll}></div>
            <div className={styles.toolbox}>
                <div className={styles.select}>
                    <label>Status zamówienia</label>
                    <select id="stateSelect" onChange={(e) => setState(e.target.value)}>
                        <option value=''>Wszystkie</option>
                        {Object.keys(orderStatus).map((stateName, index) => (
                            <option key={stateName} value={index}>{stateName}</option>
                        ))}
                    </select>
                </div>
                <div className={styles.select}>
                    <label>Typ zamówienia</label>
                    <select id="typeSelect" onChange={(e) => setType(e.target.value)}>
                        <option value=''>Wszystkie</option>
                        {Object.keys(orderType).map((stateName, index) => (
                            <option key={stateName} value={index}>{stateName}</option>
                        ))}
                    </select>
                </div>
            </div>

            <PaginationSmall pageId={pageId} pageCount={ordersData.pageCount} path={`/warehouse/orders`}/>

            <OrdersList ordersList={ordersData.items}/>

            <Pagination pageId={pageId} pageCount={ordersData.pageCount} path={`/warehouse/orders`}/>
        </>
    )
}