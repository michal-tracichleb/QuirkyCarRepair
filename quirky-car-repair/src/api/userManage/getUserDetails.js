import {BACK_END_URL} from "../../constans/backEndUrl.js";
import axios from "axios";

export async function getUserDetails(id) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    try {
        const response = await axios.get(`${BACK_END_URL}/Account/Details?id=${id}`, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });

        return { success: true, data: response.data};
    } catch (error) {
        console.error('Błąd podczas pobierania danych:', error);
        return { success: false, message: 'Błąd podczas pobierania danych' };
    }
}