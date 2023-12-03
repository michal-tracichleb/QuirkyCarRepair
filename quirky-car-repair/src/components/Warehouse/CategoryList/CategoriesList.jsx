import styles from "./CategoriesList.module.css";
import {NavLink} from "react-router-dom";
export function CategoriesList({categories}){
    return(
        <>
            <ul className={styles.parent_list}>
                {categories && categories.map((category) => (
                    <li key={category.id}>
                        <NavLink  className={styles.list_item} to={`/warehouse/${category.id}`}>{category.name}</NavLink>
                    </li>
                ))}
            </ul>
        </>

    )
}