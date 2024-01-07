import {Outlet} from "react-router-dom";
import {Container} from "../components/ContentLayout/Container/Container.jsx";
import {Sidebar} from "../components/ContentLayout/Sidebar/Sidebar.jsx";
import {MainContent} from "../components/ContentLayout/MainContent/MainContent.jsx";
import {WarehouseSidebarContent} from "../components/WarehouseSidebarContent/WarehouseSidebarContent.jsx";

export function Warehouse(){
    return(
        <>
            <Container>
                <Sidebar>
                    <WarehouseSidebarContent/>
                </Sidebar>
                <MainContent>
                    <Outlet/>
                </MainContent>
            </Container>

        </>
    )
}