import {BACK_END_URL} from "../../constans/backEndUrl.js";
import axios from "axios";

export async function editUserData(id, data) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    try {
        const response = await axios.post(`${BACK_END_URL}/Account/Edit?id=${id}`, data, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });
        return { success: true, message: 'Dane zostały zmienione', data: response.data};
    } catch (error) {
        console.error('Błąd podczas pobierania danych:', error);
        return { success: false, message: 'Błąd podczas edycji danych!' };
    }
}