import styles from "./SearchBar.module.css";
import {useEffect, useState} from "react";

export function SearchBar({list, itemToDisplay, callback, required, value, returnValue = 'id'}){
    const [inputValue, setInputValue] = useState('');
    const [selectedItemId, setSelectedItemId] = useState(null);

    useEffect(() => {
        const selectedItem = list.find(item => item[returnValue] === value);
        if(selectedItem){
            setInputValue(selectedItem[itemToDisplay]);
            setSelectedItemId(selectedItem.id);
        }
    }, [value]);
    const onChange = (e) =>{
        setInputValue(e.target.value);
        callback(null);
    }
    const onSearch = (searchTerm) =>{
        setInputValue(searchTerm);

        const selectedItem = list.find(item => item[itemToDisplay].toLowerCase() === searchTerm.toLowerCase());
        if (selectedItem) {
            setSelectedItemId(selectedItem.id);
            callback(selectedItem[returnValue]);
        } else {
            callback(null);
            setSelectedItemId(null);
        }
    }
    return(
        <div className={styles.container}>
            <div className={styles.inner}>
                <input type="text" value={inputValue} onChange={onChange} required={required}/>
                <button type="button" onClick={()=>onSearch(inputValue)}>Szukaj</button>
            </div>
            <div className={styles.dropdown}>
                {list.filter(item => {
                    const searchTerm = inputValue.toLowerCase();
                    const name = item[itemToDisplay].toLowerCase();
                    return searchTerm && name.startsWith(searchTerm) && searchTerm !== name;
                })
                    .map((item)=>(
                        <div onClick={()=>onSearch(item[itemToDisplay])}
                             className={styles.dropdown_row}
                             key={item.id ? item.id : item[itemToDisplay]}
                        >
                            {item[itemToDisplay]}
                        </div>
                    ))}
            </div>
        </div>
    )
}