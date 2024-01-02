import {BACK_END_URL} from "../constans/backEndUrl.js";
import axios from "axios";

export async function productLoader({ params: { productId } }) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    try {
        const response = await axios.get(`${BACK_END_URL}/Warehouse/Part/${productId}`, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });

        return response.data;
    } catch (error) {
        console.error('Błąd podczas pobierania danych:', error);
        return null;
    }
}