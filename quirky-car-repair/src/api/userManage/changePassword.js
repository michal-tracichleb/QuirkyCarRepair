import {BACK_END_URL} from "../../constans/backEndUrl.js";
import axios from "axios";

export async function changePassword(id, data) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    try {
        await axios.post(`${BACK_END_URL}/Account/ChangePassword?id=${id}`, data, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });

        return { success: true, message: 'Hasło zostało zmienione'};
    } catch (error) {
        console.error('Błąd podczas pobierania danych:', error);
        return { success: false, message: 'Błąd podczas zmiany hasła, proszę sprawdzić obecne hasło!' };
    }
}