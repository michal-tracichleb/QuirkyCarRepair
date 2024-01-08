import {BACK_END_URL} from "../constans/backEndUrl.js";
import axios from "axios";

export async function orderCompleted(orderId) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    try {
        await axios.get(`${BACK_END_URL}/Warehouse/OrderCompleted?id=${orderId}`, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });
        return { success: true, message: 'Wydano zamówienie' };

    } catch (error) {
        console.error('Błąd podczas pobierania danych:', error);
        return { success: false, message: 'Błąd podczas pobierania danych' };
    }
}