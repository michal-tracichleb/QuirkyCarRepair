import {Container} from "../components/ContentLayout/Container/Container.jsx";
import {MainContent} from "../components/ContentLayout/MainContent/MainContent.jsx";
import {Outlet} from "react-router-dom";

export function User(){
    return(
        <Container>
            <MainContent>
                <Outlet/>
            </MainContent>
        </Container>
    )
}