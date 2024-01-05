import styles from "./Delivery.module.css"
import {useLoaderData} from "react-router-dom";
import {useContext, useEffect, useState} from "react";
import {SearchBar} from "../SearchBar/SearchBar.jsx";
import {saveModifiedProduct} from "../../api/saveModifiedProduct.js";
import {AlertStateContext} from "../../context/AlertStateContext.js";
export function Delivery(){
    const data = useLoaderData();
    const [products] = useState(data.data);
    const [deliveryItems, setDeliveryItems] = useState([]);
    const [itemId, setItemId] = useState('');
    const [quantity, setQuantity] = useState('');
    const [,setAlert] = useContext(AlertStateContext);

    useEffect(() => {
        const handleBeforeUnload = (event) => {
            const message = "Masz niezapisane zmiany. Czy na pewno chcesz opuścić stronę?";
            event.returnValue = message;
            return message;
        };
        window.addEventListener('beforeunload', handleBeforeUnload);
        return () => {
            window.removeEventListener('beforeunload', handleBeforeUnload);
        };
    }, []);

    const onProductSelect = (id) => {
        setItemId(id);
    };
    const onQuantityChange = (e) => {
        setQuantity(e.target.value);
    };
    const handleAddItem = () => {
        if (itemId && quantity) {
            const item = products.find(item => Number(item.id) === Number(itemId));
            const newItem = { id:itemId, quantity: quantity, name: item.name};
            setDeliveryItems([...deliveryItems, newItem]);
            setItemId('');
            setQuantity('');
        }
    };
    const onSubmit = async () =>{
        if(products && deliveryItems){
            let allSuccess = true;
            for (const item of deliveryItems) {
                const product = products.find(product => Number(product.id) === Number(item.id));
                if (product){
                    const updatedProduct = { ...product, quantity: Number(product.quantity) + Number(item.quantity)};
                    const response = await saveModifiedProduct(updatedProduct);

                    if (!response.success) {
                        allSuccess = false;
                    }
                }
            }
            setAlert({text: allSuccess ? 'Zapisano dostawę' : 'Wystąpił problem podczas zapisu niektórych produktów', color: allSuccess ? 'success' : 'warning'});
            setTimeout(() => {
                setAlert();
            }, 3000);
            setItemId('');
            setQuantity('');
            setDeliveryItems([])
        }
    }
    return(
        <>
            <div className={styles.stockDelivery}>
                <h2>Wprowadź dostawę magazynową</h2>
                <div className={styles.deliveryForm}>
                    <div className={styles.formGroup}>
                        <label>Nazwa Produktu:</label>
                        <SearchBar list={products} itemToDisplay='name' callback={onProductSelect}/>
                    </div>
                    <div className={styles.formGroup}>
                        <label>Ilość:</label>
                        <input type="number" value={quantity} onChange={onQuantityChange} />
                    </div>
                    <button onClick={handleAddItem}>Dodaj Produkt</button>
                </div>
                <div className={styles.deliveryList}>
                    <h3>Lista przyjętych produktów:</h3>
                    <table className={styles.deliveryTable}>
                        <thead>
                            <tr>
                                <th>Nazwa produktu</th>
                                <th>Ilość</th>
                            </tr>
                        </thead>
                        <tbody>
                            {deliveryItems.map((item) => (
                                <tr key={item.id}>
                                    <td>{item.name}</td>
                                    <td>{item.quantity}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                    <button onClick={onSubmit} disabled={deliveryItems.length < 1}>Zapisz i wyślij</button>
                </div>
            </div>
        </>
    )
}