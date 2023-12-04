import {Layout} from "../Layout/Layout.jsx";
import {Outlet} from "react-router-dom";

/*TODO:
* Dodanie wybrania ilości produktów na stronie, dodanie przełącznika stron produktów
* Stworzyć funkcję wyświetlającą ścieżkę kategorii (po edycji endpointa)
*/

export function Warehouse() {
    return (
        <>
            <Layout>
                <Outlet/>
            </Layout>
        </>
    );
}