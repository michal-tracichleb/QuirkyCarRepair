import {Container} from "../components/ContentLayout/Container/Container.jsx";
import {MainContent} from "../components/ContentLayout/MainContent/MainContent.jsx";
import {Outlet} from "react-router-dom";
import {useContext} from "react";
import {UserStateContext} from "../context/UserStateContext.js";
import {Sidebar} from "../components/ContentLayout/Sidebar/Sidebar.jsx";
import {ServiceSidebarContent} from "../components/ServiceSidebarContent/ServiceSidebarContent.jsx";

export function Service(){
    const [userData] = useContext(UserStateContext);
    const managementPermissions = userData.role.toLocaleLowerCase() === 'admin' || userData.role.toLocaleLowerCase() === 'mechanic';
    return(
        <>
            <Container>
                {managementPermissions &&
                    <Sidebar>
                        <ServiceSidebarContent/>
                    </Sidebar>
                }
                <MainContent>
                    <Outlet/>
                </MainContent>
            </Container>
        </>
    )

}