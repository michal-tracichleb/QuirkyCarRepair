import {NavLink} from "react-router-dom";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faAngleLeft, faAngleRight} from "@fortawesome/free-solid-svg-icons";
import styles from "./PaginationSmall.module.css"

export function PaginationSmall({pageId, pageCount, path}){
    const currentPage = Number(pageId);
    const nextPageId = Number(pageId)+1;
    const prevPageId = Number(pageId)-1;

    return(
        <>
            {currentPage > 1 && <NavLink className={styles.arrow} to={`${path}/page/${prevPageId}`}><FontAwesomeIcon icon={faAngleLeft}/></NavLink>}
            <span>{currentPage}</span><span>z</span><span>{pageCount}</span>
            {currentPage < pageCount && <NavLink className={styles.arrow} to={`${path}/page/${nextPageId}`}><FontAwesomeIcon icon={faAngleRight} /></NavLink>}
        </>
    )
}