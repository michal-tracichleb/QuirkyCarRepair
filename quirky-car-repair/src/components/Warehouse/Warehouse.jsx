import {Layout} from "../Layout/Layout.jsx";
import {Outlet} from "react-router-dom";

export function Warehouse() {
    return (
        <>
            <Layout>
                <Outlet/>
            </Layout>
        </>
    );
}