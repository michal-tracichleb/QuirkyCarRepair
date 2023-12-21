import {Footer} from "../Footer/Footer.jsx";
import {MainMenu} from "../MainMenu/MainMenu.jsx";
import {Logo} from "../Logo/Logo.jsx";
import {IconMenu} from "../IconMenu/IconMenu.jsx";
import {TopBar} from "../TopBar/TopBar.jsx";
import {MainContent} from "../MainContent/MainContent.jsx";
import {useState} from "react";
import {MainSidebar} from "../MainSidebar/MainSidebar.jsx";
import {Outlet} from "react-router-dom";

export function Layout({ children }) {
    const [sidebarIsShown, setSidebarIsShown] = useState(false);
    const showSidebar = () => setSidebarIsShown(!sidebarIsShown);
    return(
        <>
            <MainContent>
                <TopBar>
                    <MainMenu setSidebarIsShown={showSidebar}/>
                    <Logo/>
                    <IconMenu/>
                </TopBar>
            <MainSidebar sidebarIsShown={sidebarIsShown} setSidebarIsShown={showSidebar}/>
                <Outlet />
            </MainContent>
            <Footer/>
        </>
    );
}
