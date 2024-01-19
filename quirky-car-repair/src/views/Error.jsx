import {Link} from "react-router-dom";

export function ErrorView(){
    return(
        <div style={{textAlign:"center"}}>
            <h1>Wystąpił nieznany błąd!</h1>
            <Link to="/">Kliknij tutaj aby wrócić na stronę główną</Link>
        </div>
    )
}