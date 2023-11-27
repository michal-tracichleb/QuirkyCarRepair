import {LoginContent} from "./LoginContent.jsx";
import {useState} from "react";
import {RegistrationContent} from "./RegistrationContent.jsx";
import {Alert} from "../Alert.jsx";

export function LoginModal({setUserIsLogged}){
    const [loginForm, setLoginForm] = useState(true);
    const [textAlert, setTextAlert] = useState();
    return(
        <div className="modal fade" id="logInModal" tabIndex="-1" aria-labelledby="logInModalLabel" aria-hidden="true">
            {textAlert && <Alert >{textAlert}</Alert>}
            <div className="modal-dialog">
                {loginForm ?
                    <LoginContent setUserIsLogged={setUserIsLogged} setLoginForm={setLoginForm}/>
                    :
                    <RegistrationContent setLoginForm={setLoginForm} setTextAlert={setTextAlert}/>
                }
            </div>
        </div>
    )
}