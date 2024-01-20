import {BACK_END_URL} from "../../constans/backEndUrl.js";
import axios from "axios";

export async function categoriesLoader() {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    try {
        const response = await axios.get(`${BACK_END_URL}/Warehouse/PartCategory`, {
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