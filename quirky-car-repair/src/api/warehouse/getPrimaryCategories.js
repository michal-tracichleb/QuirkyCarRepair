import {BACK_END_URL} from "../../constans/backEndUrl.js";
import axios from "axios";

export async function getPrimaryCategories() {
    try {
        const response = await axios.get(`${BACK_END_URL}/Warehouse/GetPrimaryCategories`);

        return { success: true, data: response.data};
    } catch (error) {
        console.error('Błąd podczas pobierania danych:', error);
        return { success: false, message: 'Błąd podczas pobierania danych' };
    }
}