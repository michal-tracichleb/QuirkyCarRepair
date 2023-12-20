import {useState} from "react";
import styles from "./RegistrationContent.module.css"
import axios from "axios";
import PhoneNumberInput from "../PhoneNumberInput.jsx";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faArrowLeft } from '@fortawesome/free-solid-svg-icons'

export function RegistrationContent({setLoginForm , setTextAlert}){
    const [passwordIsShown, setPasswordIsShown] = useState(false);
    const [errors, setErrors] = useState({});
    const [formIsValid, setFormIsValid] = useState(false);
    const [registrationData, setRegistrationData] = useState({});
    const onFormSubmit = async e =>{
        e.preventDefault();

        try{
            const response = await axios.post(
                "https://localhost:7247/api/Account/Register",
                registrationData,
            )
            if(response.status === 200){
                setTextAlert("Rejestracja przebiegła pomyślnie, teraz możesz się zalogować.")
                setTimeout(() => {
                    setTextAlert();
                }, 3000);
                setLoginForm(true);
            }
        }catch (e){
            if(e.response.data.errors){
                const responseErrors=e.response.data.errors;
                Object.keys(responseErrors).forEach((key) => {
                    handleAddError(key, responseErrors[key][0])
                });
            }
            handleAddError('registrationError', 'Wystąpił błąd w trakcie rejestracji.')
            setTimeout(() => {
                handleDeleteError('registrationError');
            }, 3000);
        }
    }

    const validRegistrationData = (index, value) =>{
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        const passwordRegex = /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/;
        switch (index){
            case 'userName':
                if(value.length > 5){
                    handleSetRegistrationData(index, value);
                    handleDeleteError(index);
                    setFormIsValid(true);
                }else{
                    handleAddError(index, 'Nazwa użytkownika musi zawierać 6 znaków')
                    setFormIsValid(false);
                }
                break;
            case 'email':
                if(emailRegex.test(value)){
                    handleSetRegistrationData(index, value);
                    handleDeleteError(index);
                    setFormIsValid(true);

                }else{
                    handleAddError(index, 'Nieprawidłowy adres email')
                    setFormIsValid(false);
                }
                break;
            case 'firstName':
                if(value){
                    handleSetRegistrationData(index, value);
                    handleDeleteError(index);
                    setFormIsValid(true);
                }else{
                    handleAddError(index, 'Nie podano imienia')
                    setFormIsValid(false);
                }
                break;
            case 'lastName':
                if(value){
                    handleSetRegistrationData(index, value);
                    handleDeleteError(index);
                    setFormIsValid(true);
                }else{
                    handleAddError(index, 'Nie podano nazwiska')
                    setFormIsValid(false);
                }
                break;
            case 'phoneNumber':
                if(value.length === 15){
                    const numericValue = value.replace(/\D/g, '');

                    if (numericValue.length >= 10) {
                        value = `+48${numericValue.slice(-9)}`;
                    }

                    handleSetRegistrationData(index, value);
                    handleDeleteError(index);
                    setFormIsValid(true);
                }else{
                    handleAddError(index, 'Błędny format numeru telefonu')
                    setFormIsValid(false);
                }
                break;
            case 'password':
                if(passwordRegex.test(value)){
                    handleSetRegistrationData(index, value);
                    handleDeleteError(index);
                    setFormIsValid(true);
                }else{
                    handleAddError(index, 'Hasło powinno zawierać: 8 znaków, wielką literę, małą literę, cyfrę oraz znak specjalny')
                    setFormIsValid(false);
                }
                break;
            case 'confirmPassword':
                if(registrationData.password === value){
                    handleSetRegistrationData(index, value);
                    handleDeleteError(index);
                    setFormIsValid(true);
                }else{
                    handleAddError(index, 'Hasła nie są identyczne')
                    setFormIsValid(false);
                }
                break;
        }
    }
    const handleSetRegistrationData = (index, value) =>{
        let newRegistrationData = {};
        newRegistrationData = {...registrationData};
        newRegistrationData[index] = value;
        setRegistrationData(newRegistrationData);
    }
    const handleAddError = (index, error) =>{
        setErrors(prevState => ({
            ...prevState,
            [index]: error
        }));
    }
    const handleDeleteError = (index) =>{
        let newErrors = {...errors};
        newErrors = Object.keys(newErrors).filter(key =>
            key !== index).reduce((obj, key) =>
            {
                obj[key] = newErrors[key];
                return obj;
            }, {}
        );
        setErrors(newErrors);
    }
    return(
        <div className="modal-content">
            <div className="modal-header">
                <a className={styles.back_link} onClick={() => setLoginForm(true)}><FontAwesomeIcon icon={faArrowLeft} /></a>
                <h5 className="modal-title" id="logInModalLabel">Rejestracja</h5>
                <button type="button" id="closeModal" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div className="modal-body">
                <form onSubmit={onFormSubmit} id="registrationForm">
                    {errors.registrationError && <div className="text-danger text-center fw-bold">{errors.registrationError}</div>}
                    <div className="mb-3">
                        <label htmlFor="userName" className="col-form-label">Login:</label>
                        <input type="text" className="form-control" name="userName" onBlur={(e) => validRegistrationData("userName",e.target.value)}/>
                        {errors.userName && <div className="text-danger text-center">{errors.userName}</div>}
                    </div>
                    <div className="mb-3">
                        <label htmlFor="email" className="col-form-label">Email:</label>
                        <input type="text" className="form-control" name="email" onBlur={(e) => validRegistrationData("email",e.target.value)}/>
                        {errors.email && <div className="text-danger text-center">{errors.email}</div>}
                    </div>
                    <div className="mb-3">
                        <label htmlFor="firstName" className="col-form-label">Imię:</label>
                        <input type="text" className="form-control" name="firstName" onBlur={(e) => validRegistrationData("firstName",e.target.value)}/>
                        {errors.firstName && <div className="text-danger">{errors.firstName}</div>}
                    </div>
                    <div className="mb-3">
                        <label htmlFor="lastName" className="col-form-label">Nazwisko:</label>
                        <input type="text" className="form-control" name="lastName" onBlur={(e) => validRegistrationData("lastName",e.target.value)}/>
                        {errors.lastName && <div className="text-danger">{errors.lastName}</div>}
                    </div>

                    <div className="mb-3">
                        <label htmlFor="phoneNumber" className="col-form-label">Numer telefonu:</label>
                        <PhoneNumberInput onBlur={(e) => validRegistrationData("phoneNumber",e.target.value)} className="form-control"/>
                        {errors.phoneNumber && <div className="text-danger">{errors.phoneNumber}</div>}
                    </div>

                    <div className="mb-3">
                        <label htmlFor="password" className="col-form-label">Hasło: </label>
                        <input type={passwordIsShown ? "text" : "password"} className="form-control" name="password" onBlur={(e) => validRegistrationData("password",e.target.value)}/>
                        {errors.password && <div className="text-danger">{errors.password}</div>}

                        <label htmlFor="confirmPassword" className="col-form-label">Potwierdź hasło: </label>
                        <input type={passwordIsShown ? "text" : "password"} className="form-control" name="confirmPassword" onChange={(e) => validRegistrationData("confirmPassword",e.target.value)}/>
                        {errors.confirmPassword && <div className="text-danger">{errors.confirmPassword}</div>}

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
            <div className="modal-footer">
                <button type="submit" form="registrationForm" className="btn btn-primary" disabled={!formIsValid && Object.keys(registrationData).length !== 6}>Zarejestruj się</button>
            </div>
        </div>
    )
}