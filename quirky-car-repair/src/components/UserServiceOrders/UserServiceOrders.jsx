import styles from "./UserServiceOrders.module.css"
import {PaginationSmall} from "../PaginationSmall/PaginationSmall.jsx";
import {ServiceOrdersList} from "../ServiceOrdersList/ServiceOrdersList.jsx";
import {Pagination} from "../Pagination/Pagination.jsx";
import {useSearchParams} from "react-router-dom";
import {useContext, useEffect, useRef, useState} from "react";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import {getServiceOrderPage} from "../../api/service/getServiceOrderPage.js";

export function UserServiceOrders(){
    const [searchParams] = useSearchParams();
    const pageId = searchParams.get('page');

    const [,setAlert] = useContext(AlertStateContext);

    const [serviceOrdersData, setServiceOrdersData] = useState([]);
    const scroll = useRef();

    useEffect(() => {
        /*fetchData();*/
        if (scroll.current) {
            scroll.current.scrollIntoView({behavior: 'smooth'});
        }
    }, [pageId]);

    const fetchData = async () =>{
        const body = {page: pageId, pageSize: 10, anyDate: true}
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
            <div ref={scroll} className={styles.container}>
                <h1>Lista zamówień</h1>
                {serviceOrdersData.items ?
                <>
                    <PaginationSmall pageId={pageId} pageCount={serviceOrdersData.pageCount} path={`/user/service/orders`}/>

                    <ServiceOrdersList ordersList={serviceOrdersData.items}/>

                    <Pagination pageId={pageId} pageCount={serviceOrdersData.pageCount} path={`/user/service/orders`}/>
                </>
                    :
                    <h2>Brak zamówień na twoim koncie</h2>
                }
            </div>
        </>

    )
}