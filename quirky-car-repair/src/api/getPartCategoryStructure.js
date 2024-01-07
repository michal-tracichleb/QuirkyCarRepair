import {BACK_END_URL} from "../constans/backEndUrl.js";
import axios from "axios";

export async function getPartCategoryStructure(id) {
    try {
        const response = await axios.get(`${BACK_END_URL}/Warehouse/GetPartCategoryStructure?id=${id}`);

        return { success: true, data: response.data};
    } catch (error) {
        console.error('Błąd podczas pobierania danych:', error);
        return { success: false, message: 'Błąd podczas pobierania danych' };
    }
}