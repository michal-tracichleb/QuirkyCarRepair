import {BACK_END_URL} from "../constans/backEndUrl.js";
import axios from "axios";

export async function saveNewVehicle(data) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    try {
        await axios.post(`${BACK_END_URL}/CarService/Vehicle`, data, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });
        return { success: true, message: 'Dodano pojazd' };
    } catch (error) {
        console.error('Błąd podczas zapisywania danych:', error.response.status);
        return { success: false, message: 'Błąd podczas zapisywania danych' };
    }
}