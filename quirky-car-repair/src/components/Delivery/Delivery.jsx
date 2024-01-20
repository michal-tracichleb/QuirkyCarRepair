import styles from "./Delivery.module.css"
import {useLoaderData} from "react-router-dom";
import {useContext, useEffect, useState} from "react";
import {SearchBar} from "../SearchBar/SearchBar.jsx";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import {postDeliveryProducts} from "../../api/warehouse/postDeliveryProducts.js";
import {Button} from "../Button/Button.jsx";
export function Delivery(){
    const data = useLoaderData();
    const [products] = useState(data.data);
    const [deliveryItems, setDeliveryItems] = useState([]);
    const [itemId, setItemId] = useState('');
    const [quantity, setQuantity] = useState('');
    const [price, setPrice] = useState('');
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
    const handleAddItem = () => {
        if (itemId && quantity && price) {
            const item = products.find(item => Number(item.id) === Number(itemId));
            const newItem = { id:itemId, quantity: parseFloat(quantity), name: item.name, unitPrice: parseFloat(price)};
            setDeliveryItems([...deliveryItems, newItem]);
            setItemId('');setQuantity('');setPrice('');
        }
    };
    const onSubmit = async () =>{
        if(deliveryItems){
            const response = await postDeliveryProducts(deliveryItems)
            setAlert({text: response.message, color: response.success ? 'success' : 'warning'});

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
                        <label htmlFor="quantity">Ilość:</label>
                        <input type="number" name="quantity" value={quantity} onChange={(e)=>setQuantity(e.target.value)} />
                    </div>
                    <div className={styles.formGroup}>
                        <label htmlFor="price">Cena:</label>
                        <input type="number" name="unitPrice" value={price} onChange={(e)=>setPrice(e.target.value)} />
                    </div>
                    <Button color="grey" width="w10" onClick={handleAddItem}>Dodaj Produkt</Button>
                </div>
                <div className={styles.deliveryList}>
                    <h3>Lista przyjętych produktów:</h3>
                    <table className={styles.deliveryTable}>
                        <thead>
                        <tr>
                            <th>Nazwa produktu</th>
                            <th>Ilość</th>
                            <th>Cena</th>
                        </tr>
                        </thead>
                        <tbody>
                        {deliveryItems.map((item) => (
                            <tr key={item.id}>
                                <td>{item.name}</td>
                                <td>{item.quantity}</td>
                                <td>{item.unitPrice}</td>
                            </tr>
                        ))}
                        </tbody>
                    </table>
                    <Button color="grey" width="w10" onClick={onSubmit} disabled={deliveryItems.length < 1}>Wyślij</Button>
                </div>
            </div>
        </>
    )
}