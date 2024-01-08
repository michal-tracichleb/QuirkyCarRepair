import {BACK_END_URL} from "../constans/backEndUrl.js";
import axios from "axios";

export async function arrangeOrder(orderId) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    try {
        await axios.get(`${BACK_END_URL}/Warehouse/ArrangeOrder?id=${orderId}`, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });
        return { success: true, message: 'Podjęto zamówienie' };

    } catch (error) {
        console.error('Błąd podczas pobierania danych:', error);
        return { success: false, message: 'Błąd podczas pobierania danych' };
    }
}