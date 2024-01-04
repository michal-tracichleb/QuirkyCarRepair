import logo from "../../assets/Logo_1.jpg";
import styles from "./CategoriesPanel.module.css";
import {NavLink} from "react-router-dom";
import {useEffect, useState, useContext} from "react";
import axios from "axios";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import {BACK_END_URL} from "../../constans/backEndUrl.js";

export function CategoriesPanel(){
    const [categories, setCategories] = useState([]);
    const [, setAlert] = useContext(AlertStateContext);

    useEffect(()=>{
        axios.get(`${BACK_END_URL}/Warehouse/GetPrimaryCategories`)
            .then((res) =>{
                setCategories(res.data)
            })
            .catch((e)=>{
                setAlert({color:'danger', text: 'Błąd podczas pobierania danych, proszę odświeżyć stronę'})
                setTimeout(() => {
                    setAlert();
                }, 3000);
            })

    },[]);

    return(
        <>
            <div className={styles.container}>
                {categories.map((category) => (
                    <NavLink to={`${category.id}?page=1`} key={category.id}>
                        <div className={styles.card}>
                            <img src={logo} alt="..." />
                            <h3>{category.name}</h3>
                        </div>
                    </NavLink>
                ))}
            </div>
        </>
    )
}