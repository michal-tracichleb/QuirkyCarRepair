import {BACK_END_URL} from "../../constans/backEndUrl.js";
import axios from "axios";

export async function serviceOrderComplaint(id, description) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    try {
        const response = await axios.get(`${BACK_END_URL}/CarService/ServiceOrderComplaint?id=${id}&description=${description}`, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });

        return { success: true, message: 'Zmieniono status zlecenia', data: response.data};
    } catch (error) {
        console.error('Błąd podczas pobierania danych:', error);
        return { success: false, message: 'Błąd podczas zapisywania danych'};
    }
}