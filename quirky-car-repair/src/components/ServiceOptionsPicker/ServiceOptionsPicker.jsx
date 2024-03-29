import styles from "./ServiceOptionsPicker.module.css"
import {SearchBar} from "../SearchBar/SearchBar.jsx";
import {useContext, useEffect, useState} from "react";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faXmark} from "@fortawesome/free-solid-svg-icons";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import {getServiceMainCategories} from "../../api/service/getServiceMainCategories.js";
import {getServiceOfferByCategory} from "../../api/service/getServiceOfferByCategory.js";
import {Button} from "../Button/Button.jsx";
import {addServiceToOrder} from "../../api/service/addServiceToOrder.js";

export function ServiceOptionsPicker({setData, orderId}){
    const [,setAlert] = useContext(AlertStateContext);
    const [isShown, setIsShown] = useState(false);
    const [serviceId, setServiceId] = useState();
    const [quantity, setQuantity] = useState();
    const [categories, setCategories] = useState([]);
    const [offer, setOffer] = useState([]);
    const [categoryId, setCategoryId] = useState('');

    useEffect(() => {
        fetchCategories();
        if(categoryId){
            fetchOffer();
        }
    }, [categoryId]);

    const fetchCategories = async () =>{
        const response = await getServiceMainCategories()
        if(response.success){
            setCategories(response.data);
        }else{
            Error({text: response.message, color: 'warning'})
        }
    }
    const fetchOffer = async () =>{
        const response = await getServiceOfferByCategory(categoryId)
        if(response.success){
            setOffer(response.data);
        }else{
            Error({text: response.message, color: 'warning'})
        }
    }
    const onServiceSelect = (value) =>{
        setServiceId(value)
    }
    const onFormSubmit = async(e) =>{
        e.preventDefault();
        const response = await addServiceToOrder(orderId, serviceId, quantity);
        if(response.success){
            Error({text: response.message, color: 'success'})
            setData(response.data);
        }else{
            Error({text: response.message, color: 'warning'})
        }
        setIsShown(false);
    }
    const Error = ({text, color}) =>{
        setAlert({text: text, color: color})
        setTimeout(() => {
            setAlert();
        }, 3000);
    }
    return(
        <>
            <div className={styles.toolbox}>
                {!isShown ?
                    <Button type="button" onClick={()=>setIsShown(true)} color="orange" width="w10">Dodaj usługę</Button>
                    :
                    <a onClick={()=>setIsShown(false)}><FontAwesomeIcon icon={faXmark} /></a>
                }
            </div>
            {isShown &&
                <form onSubmit={onFormSubmit}>
                    <div className={styles.wrapper}>
                        <div>
                            <select onChange={(e) => setCategoryId(e.target.value)} defaultValue={categoryId}>
                                <option value="" disabled>Kategoria</option>
                                {categories && categories.map((category) =>(
                                    <option key={category.id} value={category.id}>{category.name}</option>
                                ))}
                            </select>
                        </div>
                        <div>
                            <SearchBar list={offer} itemToDisplay="name" callback={onServiceSelect} required/>
                        </div>
                        <div>
                            <input type="number" name="quantity" onChange={(e)=>setQuantity(e.target.value)}/>
                        </div>
                        <div>

                        </div>
                        <div className={styles.toolbox}>
                            <Button type="submit" disabled={!serviceId || !quantity} color="orange" width="w10">Dodaj usługę</Button>
                        </div>
                    </div>
                </form>
            }
        </>
    )
}