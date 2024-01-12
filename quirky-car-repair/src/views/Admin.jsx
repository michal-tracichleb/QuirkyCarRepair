import {Sidebar} from "../components/ContentLayout/Sidebar/Sidebar.jsx";
import {MainContent} from "../components/ContentLayout/MainContent/MainContent.jsx";
import {Outlet} from "react-router-dom";
import {Container} from "../components/ContentLayout/Container/Container.jsx";
import {AdminSidebarContent} from "../components/AdminSidebarContent/AdminSidebarContent.jsx";

export function Admin(){
    return(
        <Container>
            <Sidebar>
                <AdminSidebarContent/>
            </Sidebar>
            <MainContent>
                <Outlet/>
            </MainContent>
        </Container>
    )
}