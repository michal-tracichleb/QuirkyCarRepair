import {BACK_END_URL} from "../../constans/backEndUrl.js";
import axios from "axios";

export async function assignMarginToPartCategory(categoryId, marginId) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    try {
        await axios.get(`${BACK_END_URL}/Admin/Margin/AssignToPartCategory?marginId=${marginId}&categoryId=${categoryId}`, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });

        return { success: true, message: 'Przypisano marże'};
    } catch (error) {
        console.error('Błąd podczas pobierania danych:', error);
        return { success: false, message: 'Błąd podczas pobierania danych' };
    }
}