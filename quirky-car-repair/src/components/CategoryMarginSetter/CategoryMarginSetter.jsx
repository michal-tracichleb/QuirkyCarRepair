import styles from "../MarginList/MarginList.module.css";
import {getAllMargin} from "../../api/getAllMargin.js";
import {useContext, useEffect, useState} from "react";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import {CategoryMarginList} from "../CategoryMarginList/CategoryMarginList.jsx";
import {getPrimaryCategories} from "../../api/getPrimaryCategories.js";
import {getPartCategoryStructure} from "../../api/getPartCategoryStructure.js";
import {useNavigate, useSearchParams} from "react-router-dom";
import {assignMarginToPartCategory} from "../../api/assignMarginToPartCategory.js";
import {getServiceMainCategories} from "../../api/getServiceMainCategories.js";
import {assignMarginToServiceCategory} from "../../api/assignMarginToServiceCategory.js";

export function CategoryMarginSetter(){
    const navigate = useNavigate();
    const [searchParams] = useSearchParams();
    const param = Number(searchParams.get('mode'));

    const [,setAlert] = useContext(AlertStateContext);

    const [mode, setMode] = useState(param)
    const [margins, setMargins] = useState([]);
    const [categories, setCategories] = useState([]);
    const [primaryCategories, setPrimaryCategories] = useState([]);
    const [primaryCategoryId, setPrimaryCategorId] = useState(0);

    useEffect(()=>{
        fetchMargins();

        if(Number(mode) === 3){
            fetchServiceCategories();
        }else{
            fetchProductPrimaryCategories();
        }

    },[mode]);
    const fetchProductPrimaryCategories = async () =>{
        const response = await getPrimaryCategories();
        if(response.success){
            if(mode === 1){
                setCategories(response.data)
            }else{
                setPrimaryCategories(response.data)
            }
        }else{
            Error({text: response.message, color: 'warning'})
        }
    }
    const fetchProductChildCategories = async (id) =>{
        const response = await getPartCategoryStructure(id);
        if(response.success){
            setCategories(response.data.subcategories)
        }else{
            Error({text: response.message, color: 'warning'})
        }
    }
    const fetchServiceCategories = async () =>{
        const response = await getServiceMainCategories();
        if(response.success){
            setCategories(response.data)
        }else{
            Error({text: response.message, color: 'warning'})
        }
    }
    const fetchMargins = async () =>{
        const response = await getAllMargin();
        if(response.success){
            setMargins(response.data)
        }else{
            Error({text: response.message, color: 'warning'})
        }
    }
    const onMarginSelect = async (categoryId, marginId) =>{
        let response;
        if(Number(mode) === 3){
            response = await assignMarginToServiceCategory(categoryId, marginId);
        }else{
            response = await assignMarginToPartCategory(categoryId, marginId);
        }
        if(response.success){
            setCategories(prevState => {
                const updatedCategories = prevState.map(item => {
                    if (item.id === categoryId) {
                        return { ...item, marginId: marginId };
                    }
                    return item;
                });
                return updatedCategories;
            });
        }
        Error({text: response.message, color: response.success ? 'success' : 'warning'})
    }
    const onPrimaryCategorySelect = (e) =>{
        fetchProductChildCategories(e.target.value)
        setPrimaryCategorId(e.target.value);
    }
    const setParam = (e) =>{
        setCategories([])
        setMode(Number(e.target.value));
        navigate(`?mode=${e.target.value}`);
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
                <div>
                    <select value={mode} onChange={setParam}>
                        <option value={1}>Kategorie główne produktów</option>
                        <option value={2}>Podkategorie produktów</option>
                        <option value={3}>Kategorie serwisowe</option>
                    </select>
                </div>
                {mode === 2 &&
                    <div>
                        <select onChange={onPrimaryCategorySelect} value={primaryCategoryId}>
                            <option value={0} disabled>Wybierz kategorię</option>
                            {primaryCategories && primaryCategories.map((category) =>(
                                <option value={category.id} key={category.id}>{category.name}</option>
                            ))}
                        </select>
                    </div>
                }
            </div>
            <CategoryMarginList categories={categories} margins={margins} onMarginSelect={onMarginSelect}/>
        </>
    )
}