import {SubNav} from "../SubNav/SubNav.jsx";

export function ServiceSidebarContent(){

    return(
        <>
            <SubNav title='Nowe zlecenie' to='/service/order/new'/>
            <SubNav title='Terminarz' to=''/>
            <SubNav title='Zlecenia oczekujące' to='/service/orders?page=1&state=0'/>
        </>
    )
}