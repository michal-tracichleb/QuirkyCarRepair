import {BACK_END_URL} from "../../constans/backEndUrl.js";
import axios from "axios";

export async function editUserRole(userId, roleId) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    try {
        await axios.get(`${BACK_END_URL}/Admin/Account/EditUserRole?userId=${userId}&newRoleId=${roleId}`, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });
        return { success: true, message: 'Rola użytkownika została zmieniona'};
    } catch (error) {
        console.error('Błąd podczas pobierania danych:', error);
        return { success: false, message: 'Błąd podczas edycji danych!' };
    }
}