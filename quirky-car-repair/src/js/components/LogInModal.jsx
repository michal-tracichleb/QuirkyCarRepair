import {useState} from "react";
import axios from "axios";

export default function LogInModal({setUserIsLogged, setUserData}) {
    const [errors, setErrors] =useState({});
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");

    const [isShown, setIsShown] = useState(true);

    const togglePassword = () => {
        setIsShown((isShown) => !isShown);
    };
    const handleSetErrors = (props) =>{
        setErrors(props);
    }
    const handleSetUserIsLogged = (props) =>{
        setUserIsLogged(true);
    }
    const handleSetUserData = (userData) =>{
        let newUserData = {'bearerToken': userData};
        setUserData(newUserData)
    }

    function onClicklogin(){

        let loginData = {
            email: login,
            password : password
        };

        /*Validation login data section*/
        let errors = {};
        let isValid = true;

        if (!loginData["email"]) {
            isValid = false;
            errors["login"] = "Proszę wprowadzić login.";
        }

        if (!loginData["password"]) {
            isValid = false;
            errors["password"] = "Proszę wprowadzić hasło.";
        }
        handleSetErrors(errors)

        if(!isValid){
            return;
        }
        /*End validation login data section*/

        UserLogin(loginData);
    }

    function UserLogin(loginData) {
        const baseURL = "https://localhost:7247/api/Account/Login";

        const getResponse = (props)=>{
            let loginResponse = [];
            loginResponse['status'] = props.status;
            if(loginResponse['status'] === 200){
                loginResponse['bearerToken'] = props.data.accessToken;
            }
            CheckLoginSuccess(loginResponse)
        }

        axios.post( baseURL, loginData)

            .then((response ) => getResponse(response))
            .catch((response ) => getResponse(response.response))
    }

    function CheckLoginSuccess(loginResponse){
        if(loginResponse.status === 200){
            document.getElementById('closeModal').click()
            handleSetUserIsLogged(true);
            handleSetUserData(loginResponse.bearerToken);
        }else{
            handleSetErrors({'loginFailed':"Logowanie nie powiodło się, sprawdź login lub hasło!"})
        }
    }

    return (
            <div className="modal fade" id="logInModal" tabIndex="-1" aria-labelledby="logInModalLabel" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title" id="logInModalLabel">Zaloguj się</h5>
                            <button type="button" id="closeModal" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">
                            <form>
                                <div className="text-danger">{errors.loginFailed}</div>
                                <div className="mb-3">
                                    <label htmlFor="login" className="col-form-label">Login:</label>
                                    <input type="text" className="form-control" id="login" onChange={(e)=> {setLogin(e.target.value)}}/>
                                    <div className="text-danger">{errors.login}</div>
                                </div>
                                <div className="mb-3">
                                    <label htmlFor="password" className="col-form-label">Hasło: </label>
                                    <input type={isShown ? "text" : "password"} className="form-control" id="password" onChange={(e)=> {setPassword(e.target.value)}}/>

                                    <label htmlFor="checkbox">Pokaż hasło</label>
                                    <input
                                        id="checkbox"
                                        type="checkbox"
                                        checked={isShown}
                                        onChange={togglePassword}
                                    />

                                    <div className="text-danger">{errors.password}</div>
                                </div>
                            </form>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-primary" onClick={onClicklogin} >Zaloguj</button>
                        </div>
                    </div>
                </div>
            </div>
    );
}
