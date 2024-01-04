import {NavLink} from "react-router-dom";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faAngleLeft, faAngleRight} from "@fortawesome/free-solid-svg-icons";
import styles from "./Pagination.module.css"

export function Pagination({pageId, pageCount, path}){
    const currentPage = Number(pageId);
    const nextPageId = Number(pageId)+1;
    const prevPageId = Number(pageId)-1;

    const getPageNumbers = () =>{
        const navLinks = [];
        const startPage = Math.max(currentPage - 1, 1);
        const endPage = Math.min(startPage + 2, pageCount);
        for (let i = startPage; i <= endPage; i++) {
            let isActive = currentPage === i;

            navLinks.push(
                <NavLink key={i} className={`${styles.link} ${isActive ? styles.active : ""}`} to={`${path}?page=${i}`}>{i}</NavLink>
            );
        }
        return navLinks;
    }
    return(
        <div className={styles.pagination}>
            {currentPage > 1 && <NavLink className={styles.text} to={`${path}?page=${prevPageId}`}><FontAwesomeIcon icon={faAngleLeft}/><span>POPRZEDNIA</span></NavLink>}
            {getPageNumbers()}
            <span>z</span><span>{pageCount}</span>
            {currentPage < pageCount && <NavLink className={styles.text} to={`${path}?page=${nextPageId}`}><span>NASTĘPNA</span><FontAwesomeIcon icon={faAngleRight} /></NavLink>}
        </div>
    )
}