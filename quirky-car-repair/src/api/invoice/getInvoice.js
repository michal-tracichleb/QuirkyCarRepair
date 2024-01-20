import {BACK_END_URL} from "../../constans/backEndUrl.js";
import axios from "axios";

export async function getInvoice(orderId) {
    try {
        const response = await axios.get(`${BACK_END_URL}/CarService/GetInvoicePDF?serviceOrderId=${orderId}`,{
            responseType: 'arraybuffer',
        });

        return { success: true, data: response.data };
    } catch (error) {
        console.error('Błąd podczas pobierania danych:', error);
        return { success: false, message: 'Błąd podczas pobierania danych' };
    }
}