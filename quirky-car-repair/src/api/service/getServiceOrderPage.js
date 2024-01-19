import {BACK_END_URL} from "../../constans/backEndUrl.js";
import axios from "axios";

export async function getServiceOrderPage(data) {
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];
    const body={
        page: data && data.page ? data.page : 1,
        pageSize: data && data.pageSize ? data.pageSize : 10,
        anyDate: data && data.anyDate !==undefined ? data.anyDate : true,
        fromDate: data && data.fromDate ? data.fromDate : null,
        toDate: data && data.toDate ? data.toDate : null,
        sortBy: "string",
        sortDirection:0,
        orderStates:data && data.orderStates ? data.orderStates : []
    };

    try {
        const response = await axios.post(`${BACK_END_URL}/CarService/GetServiceOrderPage`, body, {
            headers: {
                Authorization: `Bearer ${user.token}`,
            },
        });
        return { success: true, data: response.data};
    } catch (error) {
        console.error('Błąd podczas pobierania danych:', error);
        return { success: false, message: 'Błąd podczas pobierania danych' };
    }
}