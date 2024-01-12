import {BACK_END_URL} from "../constans/backEndUrl.js";
import axios from "axios";

export async function saveModifiedProduct(data) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    if(!data.id){
        return null;
    }
    try {
        await axios.put(`${BACK_END_URL}/Warehouse/Part/${data.id}`, data, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });
        return { success: true, message: 'Zmodyfikowano produkt' };
    } catch (error) {
        console.error('Błąd podczas zapisywania danych:', error.response.status);
        return { success: false, message: 'Błąd podczas zapisywania danych' };
    }
}