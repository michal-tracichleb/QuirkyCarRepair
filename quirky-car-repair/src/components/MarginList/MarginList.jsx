import styles from "./MarginList.module.css";
import {ProductManageLink} from "../ProductManageLink/ProductManageLink.jsx";
import {useContext, useEffect, useState} from "react";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import {saveNewMargin} from "../../api/margins/saveNewMargin.js";
import {updateMargin} from "../../api/margins/updateMargin.js";
import {getAllMargin} from "../../api/margins/getAllMargin.js";

export function MarginList(){
    const [margins, setMargins] = useState([])
    const [marginName, setMarginName] = useState('');
    const [marginValue, setMarginValue] = useState('');
    const [marginId, setMarginId] = useState(null);
    const [formIsShown, setFormIsShown] = useState(false);
    const [,setAlert] = useContext(AlertStateContext);

    useEffect(()=>{
        fetchAllMargins();

    },[]);

    const fetchAllMargins = async () =>{
        const response = await getAllMargin();
        if(response.success){
            setMargins(response.data)
        }else{
            Error({text: response.message, color: 'warning'})
        }
    }
    const handleEditMargin = (id) =>{
        const margin = margins.find(margin => margin.id === id);
        setMarginId(id);
        setMarginName(margin.name);
        setMarginValue(margin.value);
        setFormIsShown(true);
    }

    const onSubmit = async (e) =>{
        e.preventDefault();
        let response;
        const data = {};
        data.name = marginName;
        data.value = parseFloat(marginValue);

        if(marginId){
            data.id = marginId;
            response = await updateMargin(data);
        }else{
            response = await saveNewMargin(data);
        }

        if(response.success){
            Error({text: response.message, color: 'success'});
            setFormIsShown(false);
            fetchAllMargins();
        }else{
            Error({text: response.message, color: 'warning'})
        }
    }
    /*const handleRemoveMargin = async (id) =>{
        const userConfirmed = window.confirm('Czy na pewno chcesz usunąć marżę?');

        if(userConfirmed) {
            const response = await removeMargin(id);
            if(response.success){
                Error({text: response.message, color: 'success'})

                const updatedMargins = [...margins];
                const filteredMargins = updatedMargins.filter((margin) => margin.id !== id);
                setMargins(filteredMargins);
            }else{
                Error({text: response.message, color: 'warning'})
            }
        }
    }*/
    const Error = ({text, color}) =>{
        setAlert({text: text, color: color})
        setTimeout(() => {
            setAlert();
        }, 3000);
    }
    return(
        <>
            <div className={styles.toolbox}>
                <ProductManageLink onClick={()=>setFormIsShown(true)}>Dodaj</ProductManageLink>
            </div>
            {formIsShown &&
                <form onSubmit={onSubmit}>
                    <div className={styles.formContainer}>
                        <div>
                            <label htmlFor="name">Nazwa</label>
                            <input type="text" name="name" value={marginName} onChange={(e) => setMarginName(e.target.value)}/>
                        </div>
                        <div>
                            <label htmlFor="value">Nazwa</label>
                            <input type="number" name="value" value={marginValue} onChange={(e) => setMarginValue(e.target.value)}/>
                        </div>
                        <button disabled={!marginName || !marginValue} type="submit">Zapisz</button>
                    </div>
                </form>
            }

            <div className={styles.container}>
                {margins && margins.map((margin) =>(
                    <div className={styles.marginContainer} key={margin.id}>
                        <div className={styles.margin}>
                            <h3>{margin.name}</h3>
                            <p>Wartość: {margin.value} %</p>
                        </div>
                        <div className={styles.manage}>
                            <ProductManageLink onClick={()=>handleEditMargin(margin.id)}>Edytuj</ProductManageLink>
                            {/*<ProductManageLink onClick={()=>handleRemoveMargin(margin.id)}>Usuń</ProductManageLink>*/}
                        </div>
                    </div>
                ))}
            </div>
        </>

    )
}