import styles from "./WarehouseSidebarContent.module.css"
import {useParams} from "react-router-dom";
import {useContext, useEffect, useState} from "react";
import {getPrimaryCategories} from "../../api/getPrimaryCategories.js";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import {getPartCategoryStructure} from "../../api/getPartCategoryStructure.js";
import {SubNav} from "../SubNav/SubNav.jsx";
import {UserStateContext} from "../../context/UserStateContext.js";

export function WarehouseSidebarContent(){
    const { categoryId } = useParams();

    const [primaryCategories, setPrimaryCategories] = useState([]);
    const [subCategories, setSubCategories] = useState([]);

    const [,setAlert] = useContext(AlertStateContext);
    const [userData] = useContext(UserStateContext);

    const managementPermissions = userData.role.toLocaleLowerCase() === ('admin' || 'storekeeper');


    useEffect(() => {
        fetchPrimaryCategories();
    }, []);

    useEffect(() => {
        if(categoryId){
            fetchSubCategories();
        }
    }, [categoryId]);
    const fetchPrimaryCategories = async () =>{
        const response = await getPrimaryCategories();
        if(response.success){
            setPrimaryCategories(response.data)
        }else{
            Error(response.message, 'warning')
        }
    }
    const fetchSubCategories = async () =>{
        const response = await getPartCategoryStructure(categoryId);
        if(response.success){
            setSubCategories(response.data.subcategories)
        }else{
            Error(response.message, 'warning')
        }
    }
    const Error = (message, color)=>{
        setAlert({text: message, color: color});
        setTimeout(() => {
            setAlert();
        }, 3000);
    }
    return(
        <>
            <SubNav title='Kategorie główne'>
                {primaryCategories && primaryCategories.length > 0 && primaryCategories.map((category) => (
                    <a href={`/warehouse/${category.id}?page=1`} key={category.id} className={styles.DropdownLink}>
                        <span className={styles.SidebarLabel}>{category.name}</span>
                    </a>
                ))}
            </SubNav>
            {categoryId && subCategories.length > 0 &&
                <SubNav title='Podkategorie'>
                    {subCategories && subCategories.length > 0 && subCategories.map((category) => (
                        <a href={`/warehouse/${category.id}?page=1`} key={category.id} className={styles.DropdownLink}>
                            <span className={styles.SidebarLabel}>{category.name}</span>
                        </a>
                    ))}
                </SubNav>
            }

            {managementPermissions &&
                <SubNav title='Dostawa' to='/warehouse/delivery'/>
            }
        </>

    )
}