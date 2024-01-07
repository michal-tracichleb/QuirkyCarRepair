import {BACK_END_URL} from "../constans/backEndUrl.js";
import axios from "axios";

export async function postDeliveryProducts(data) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    try {
        await axios.post(`${BACK_END_URL}/Warehouse/DeliveryParts`, data, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });
        return { success: true, message: 'Zapisano dostawę' };
    } catch (error) {
        console.error('Błąd podczas zapisywania danych:', error);
        return { success: false, message: 'Błąd podczas zapisywania dostawy' };
    }
}