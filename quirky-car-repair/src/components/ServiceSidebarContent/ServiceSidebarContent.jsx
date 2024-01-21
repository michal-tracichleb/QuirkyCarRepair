import {SubNav} from "../SubNav/SubNav.jsx";

export function ServiceSidebarContent(){

    return(
        <>
            <SubNav title='Nowe zlecenie' to='/service'/>
            <SubNav title='Terminarz' to='/service/orders/schedule'/>
            <SubNav title='Zlecenia' to='/service/orders?page=1&state=0'/>
        </>
    )
}