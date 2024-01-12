import {SubNav} from "../SubNav/SubNav.jsx";
import styles from "../WarehouseSidebarContent/WarehouseSidebarContent.module.css";

export function AdminSidebarContent(){
    return(
        <>
            <SubNav title='Zarządzanie marżami' to='/admin/margin/manage'/>
            <SubNav title='Nadaj marże'>
                <a href={`/admin/margin/setter?mode=1`} className={styles.DropdownLink}>
                    <span className={styles.SidebarLabel}>Kategorie główne produktów</span>
                </a>
                <a href={`/admin/margin/setter?mode=2`} className={styles.DropdownLink}>
                    <span className={styles.SidebarLabel}>Podkategorie</span>
                </a>
                <a href={`/admin/margin/setter?mode=3`} className={styles.DropdownLink}>
                    <span className={styles.SidebarLabel}>Serwis</span>
                </a>
            </SubNav>
            <SubNav title='Użytkownicy' />
        </>
    )
}