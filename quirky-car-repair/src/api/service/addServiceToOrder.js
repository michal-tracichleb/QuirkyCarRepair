import {BACK_END_URL} from "../../constans/backEndUrl.js";
import axios from "axios";

export async function addServiceToOrder(orderId, offerId, amount) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    try {
        const response = await axios.get(`${BACK_END_URL}/CarService/AddServiceToOrder?serviceOrderId=${orderId}&serviceOfferId=${offerId}&numberOfServices=${amount}`, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });
        return {success: true, message: 'Dodano usługę', data: response.data};
    } catch (error) {
        console.error('Błąd podczas zapisywania danych:', error);
        return { success: false, message: error.response.data};
    }
}