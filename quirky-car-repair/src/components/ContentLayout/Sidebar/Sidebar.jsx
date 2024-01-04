import styles from "./Sidebar.module.css";
import {useWindowWidth} from "../../../hooks/useWindowWidth.jsx";
import {useEffect, useRef, useState} from "react";
export function Sidebar({children}){
    const isWideScreen = useWindowWidth(767);
    const [sidebarIsShown, setSidebarIsShown] = useState(isWideScreen);
    const sidebarRef = useRef(null);

    useEffect(() => {
        setSidebarIsShown(isWideScreen);

        /*Zamknięcie po kliknięciu na zewnątrz*/
        const handleOutsideClick = (event) => {
            if (sidebarRef.current && !sidebarRef.current.contains(event.target) && !isWideScreen) {
                setSidebarIsShown(false);
            }
        };

        document.addEventListener('mousedown', handleOutsideClick);

        return () => {
            document.removeEventListener('mousedown', handleOutsideClick);
        };

    }, [isWideScreen]);
    const toggleSidebar = () => {
        setSidebarIsShown(!sidebarIsShown);
    };

    return(
        <div className={`${styles.sidebarContainer} ${!sidebarIsShown? styles.inactive : ''}`} ref={sidebarRef}>
            <div className={styles.sidebarToggle}>
                <span onClick={toggleSidebar}>☰</span>
            </div>

            <div className={`${styles.sidebar} ${!sidebarIsShown? styles.inactive : ''}`}>
                {children}
            </div>

        </div>
    )
}
