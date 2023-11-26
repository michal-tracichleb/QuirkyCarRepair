import {useState} from "react";
import axios from "axios";
import {prepareUserData} from "../../utlis/prepareUserData.js";

export function LoginContent({setUserIsLogged}){
    const [passwordIsShown, setPasswordIsShown] = useState(false);
    const [errors, setErrors] = useState([]);
    const onFormSubmit = async e =>{
        e.preventDefault();
        let isValid;

        const loginData = {
            'email': e.target.email.value,
            'password': e.target.password.value
        };
        isValid = validateLoginData(loginData);

        if(!isValid){
            return;
        }

        try{
            const response = await axios.post(
                "https://localhost:7247/api/Account/Login",
                loginData,
            )
            if(response.status === 200){
                prepareUserData(response.data);
                document.getElementById("closeModal").click();
                setUserIsLogged(true);
            }
        }catch (e){
            let error = [];
            error['loginError'] = "Nieprawidłowe dane logowania!";
            setErrors(error);
        }
    }

    const validateLoginData = (data) => {

        let errors = [];
        let isValid = true;
        const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

        if (!data["email"] || !regex.test(data["email"])) {
            isValid = false;
            errors["email"] = "Proszę wprowadzić poprawny email.";
        }

        if (!data["password"]) {
            isValid = false;
            errors["password"] = "Proszę wprowadzić hasło.";
        }
        setErrors(errors)
        return isValid;
    }

    return(
        <div className="modal-content">
            <div className="modal-header">
                <h5 className="modal-title" id="logInModalLabel">Zaloguj się</h5>
                <button type="button" id="closeModal" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div className="modal-body">
                {errors.loginError && <div className="text-danger">{errors.loginError}</div>}
                <form onSubmit={onFormSubmit} id="loginForm">
                    <div className="mb-3">
                        <label htmlFor="email" className="col-form-label">Email:</label>
                        <input type="text" className="form-control" name="email"/>
                        {errors.email && <div className="text-danger">{errors.email}</div>}
                    </div>
                    <div className="mb-3">
                        <label htmlFor="password" className="col-form-label">Hasło: </label>
                        <input type={passwordIsShown ? "text" : "password"} className="form-control" name="password" />
                        {errors.password && <div className="text-danger">{errors.password}</div>}

                        <label htmlFor="checkbox">Pokaż hasło</label>
                        <input
                            id="checkbox"
                            type="checkbox"
                            checked={passwordIsShown}
                            onChange={()=>setPasswordIsShown(!passwordIsShown)}
                        />
                    </div>
                </form>
            </div>
            <div className="modal-footer ">
                <div className="col">
                    <button type="button" className="btn btn-primary" >Rejestracja</button>
                </div>
                <div className="col">
                    <button type="submit" form="loginForm" className="btn btn-primary float-end" >Zaloguj</button>
                </div>
            </div>
        </div>
    )
}