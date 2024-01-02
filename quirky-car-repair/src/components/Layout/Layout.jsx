import {AlertStateContext} from "../../context/AlertStateContext.js";
import {Footer} from "../Footer/Footer.jsx";
import {MainMenu} from "../MainMenu/MainMenu.jsx";
import {Logo} from "../Logo/Logo.jsx";
import {IconMenu} from "../IconMenu/IconMenu.jsx";
import {TopBar} from "../TopBar/TopBar.jsx";
import {MainContent} from "../MainContent/MainContent.jsx";
import {useState} from "react";
import {MainSidebar} from "../MainSidebar/MainSidebar.jsx";
import {Outlet} from "react-router-dom";
import {Alert} from "../Alert/Alert.jsx";
import {UserStateContext} from "../../context/UserStateContext.js";

export function Layout() {
    const [sidebarIsShown, setSidebarIsShown] = useState(false);
    const [alert, setAlert] = useState();

    const [userData, setUserData] = useState(() => {
        return sessionStorage["user"]
            ? JSON.parse(sessionStorage["user"])
            : [];
    });

    const showSidebar = () => setSidebarIsShown(!sidebarIsShown);
    return(
        <>
            <UserStateContext.Provider value={[userData, setUserData]}>
                <AlertStateContext.Provider value={[alert, setAlert]}>
                    <MainContent>
                        {alert && alert.text && <Alert color={alert.color ? alert.color : undefined}>{alert.text}</Alert>}
                        <TopBar>
                            <MainMenu setSidebarIsShown={showSidebar}/>
                            <Logo/>
                            <IconMenu/>
                        </TopBar>
                        <MainSidebar sidebarIsShown={sidebarIsShown} setSidebarIsShown={showSidebar}/>
                        <Outlet />
                    </MainContent>
                    <Footer/>
                </AlertStateContext.Provider>
            </UserStateContext.Provider>

        </>
    );
}
