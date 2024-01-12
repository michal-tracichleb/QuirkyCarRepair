import {BACK_END_URL} from "../constans/backEndUrl.js";
import axios from "axios";

export async function createServiceOrder(data) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    try {
        const response = await axios.post(`${BACK_END_URL}/CarService/CreateServiceOrder`, data, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });
        return {success: true, message: 'Złożono zamówienie', data: response.data};
    } catch (error) {
        console.error('Błąd podczas zapisywania danych:', error);
        return { success: false, message: error.response.data};
    }
}