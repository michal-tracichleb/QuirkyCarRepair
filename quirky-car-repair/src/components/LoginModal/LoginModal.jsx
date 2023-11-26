import {LoginContent} from "./LoginContent.jsx";

export function LoginModal({setUserIsLogged}){
    return(
        <div className="modal fade" id="logInModal" tabIndex="-1" aria-labelledby="logInModalLabel" aria-hidden="true">
            <div className="modal-dialog">
                <LoginContent setUserIsLogged={setUserIsLogged}/>
            </div>
        </div>
    )
}