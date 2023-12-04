import logo from "../../../assets/Logo_1.jpg";
import styles from "./CategoriesPanel.module.css";
import {NavLink} from "react-router-dom";
import {useEffect, useState, useContext} from "react";
import axios from "axios";
import {AlertStateContext} from "../../../context/AlertStateContext.js";

export function CategoriesPanel(){
    const [categories, setCategories] = useState([]);
    const [alert, setAlert] = useContext(AlertStateContext);

    useEffect(()=>{
        axios.get('https://localhost:7247/api/Warehouse/GetPrimaryCategories')
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
            <div className="row justify-content-center mt-2">
                {categories.map((category) => (
                    <div key={category.id} style={{width: '20rem'}}>
                        <img src={logo} className={`card-img-top ${styles.img}`} alt="..." />
                        <div className="card bg-dark text-lg-center" style={{color: 'white'}}>
                            <div className="card-body">
                                <NavLink to={`${category.id}`} className={styles.link}><h5 className="card-title">{category.name}</h5></NavLink>
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        </>

    )
}