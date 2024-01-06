import React, { useState, useRef, useEffect } from 'react';
import styles from './DropdownList.module.css';

export function DropdownList({trigger, listHeader, list}){
    const [open, setOpen] = useState(false);
    const dropdownRef = useRef(null);

    useEffect(() => {
        const handleOutsideClick = (event) => {
            if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
                setOpen(false);
            }
        };

        document.addEventListener('mousedown', handleOutsideClick);

        return () => {
            document.removeEventListener('mousedown', handleOutsideClick);
        };
    }, []);

    const toggleDropdown = () => {
        setOpen(!open);
    };

    return (
            <div ref={dropdownRef}>
                <div onClick={toggleDropdown}>
                    {trigger}
                </div>

                <div className={`${styles.dropdown_menu} ${open? styles.active : styles.inactive}`} >
                    {listHeader && <h4>{listHeader}</h4>}
                    {list}
                </div>
            </div>
    );
}