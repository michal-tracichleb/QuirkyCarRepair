import {BACK_END_URL} from "../../constans/backEndUrl.js";
import axios from "axios";

export async function removeMargin(id) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    try {
        await axios.delete(`${BACK_END_URL}/Admin/Margin/Delete?id=${id}`, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });
        return { success: true, message: 'Usunięto marże' };
    } catch (error) {
        console.error('Błąd podczas usuwania danych:', error.response.status);
        return { success: false, message: 'Błąd podczas usuwania' };
    }
}