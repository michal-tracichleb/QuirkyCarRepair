import {BACK_END_URL} from "../constans/backEndUrl.js";
import axios from "axios";

export async function updateMargin(data) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    try {
        await axios.put(`${BACK_END_URL}/Admin/Margin/Update?id=${data.id}`, data, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });
        return { success: true, message: 'Zaktualizowano marże' };
    } catch (error) {
        console.error('Błąd podczas zapisywania danych:', error.response.status);
        return { success: false, message: 'Błąd podczas zapisywania danych' };
    }
}