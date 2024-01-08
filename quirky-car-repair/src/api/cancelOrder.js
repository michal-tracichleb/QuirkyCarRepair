import {BACK_END_URL} from "../constans/backEndUrl.js";
import axios from "axios";

export async function cancelOrder(orderId) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    try {
        await axios.get(`${BACK_END_URL}/Warehouse/CancelOrder?id=${orderId}`, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });
        return { success: true, message: "Anulowano zamówienie"};
    } catch (error) {
        console.error('Wystąpił błąd:', error);
        return { success: false, message: 'Wystąpił błąd' };
    }
}