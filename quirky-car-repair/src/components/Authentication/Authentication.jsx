import styles from "./Authentication.module.css"
import {useContext, useEffect, useState} from "react";
import axios from "axios";
import {BACK_END_URL} from "../../constans/backEndUrl.js";
import {prepareUserData} from "../../utlis/prepareUserData.js";
import {useValidation} from "../../hooks/useValidation.jsx";
import PhoneNumberInput from "../PhoneNumberInput/PhoneNumberInput.jsx";
import {formFields, signUpFields, signUpTouched, signInFields, signInTouched} from "../../constans/formFields.js";
import {Link, useNavigate, useSearchParams} from "react-router-dom";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import {UserStateContext} from "../../context/UserStateContext.js";

export function Authentication(){
    const [searchParams] = useSearchParams();
    const isSignIn = searchParams.get('mode') === 'signin';
    const [, setAlert] = useContext(AlertStateContext);

    const [,setUserData] = useContext(UserStateContext);

    let getFormFields = isSignIn ? signInFields : signUpFields;
    let getTouchedFields = isSignIn ? signInTouched : signUpTouched;

    const [passwordIsShown, setPasswordIsShown] = useState(false);
    const [initialFields, setInitialFields] = useState(getFormFields);
    const [touchedFields, setTouchedFields] = useState(getTouchedFields);
    let errors = useValidation(initialFields, touchedFields, isSignIn);
    const credentialsKeys = Object.keys(initialFields);
    const navigate = useNavigate();

    const anyErrors = Object.values(errors).filter(({ isError }) => isError === true);
    const nothingIsTouched = Object.values(touchedFields).includes(true);

    useEffect(() => {
        setInitialFields(getFormFields)
        setTouchedFields(getTouchedFields)
    }, [isSignIn]);

    const inputChangeHandler = e => {
        const key = e.target.name;
        const value = e.target.value;
        setInitialFields(prevValues => ({ ...prevValues, [key]: value }));
    };
    const inputTouchedHandler = e => {
        const key = e.target.name;
        setTouchedFields(prevValues => ({ ...prevValues, [key]: true }));
    };
    const onFormSubmit = async e =>{
        e.preventDefault();
        const url = `${BACK_END_URL}/Account/${isSignIn ? 'Login' : 'Register'}`;

        try{
            const response = await axios.post(
                url,
                initialFields,
            )
            if(response.status === 200){
                if(isSignIn){
                    prepareUserData(response.data);
                    setUserData(JSON.parse(sessionStorage["user"]));

                    setAlert({text: 'Zalogowano pomyślnie'});
                    navigate('/');

                }else{
                    setAlert({text: 'Rejestracja przebiegła pomyślnie, teraz możesz się zalogować'});
                    navigate('/authentication?mode=signin');
                }
                setTimeout(() => {
                    setAlert();
                }, 3000);
            }
        }catch (e){
            setAlert({text: 'Wystąpił błąd, spróbuj ponownie', color:'warning'});
            setTimeout(() => {
                setAlert();
            }, 3000);
        }
    }

    const FieldsInputs = credentialsKeys.map(key => {
        const input = formFields[key];
        const { isError, errorFeedback } = errors[key] || {};
        const isTouched = touchedFields[key];

        let value = initialFields[key];

        switch (input.type) {
            case 'text':
                return (
                    <div className={styles.authentication_container} key={key}>
                        <label htmlFor={key}>{input.label}</label>
                        <input
                            type={input.type}
                            name={key}
                            placeholder={input.placeholder}
                            onChange={inputChangeHandler}
                            onBlur={inputTouchedHandler}
                        />
                        {isError && isTouched && <span className={styles.error}>{errorFeedback}</span>}
                    </div>
                );
            case 'password':
                return (
                    <div className={styles.authentication_container} key={key}>
                        <label htmlFor={key}>{input.label}</label>
                        <input
                            type={passwordIsShown ? "text" : "password"}
                            name={key}
                            placeholder={input.placeholder}
                            onChange={inputChangeHandler}
                            onBlur={inputTouchedHandler}
                        />
                        {isError && isTouched && <span className={styles.error}>{errorFeedback}</span>}
                    </div>
                );
            case 'tel':
                return (
                    <div className={styles.authentication_container} key={key}>
                        <label htmlFor={key}>{input.label}</label>
                        <PhoneNumberInput
                            onChange={inputChangeHandler}
                            onBlur={inputTouchedHandler}
                            value={value}
                        />
                        {isError && isTouched && <span className={styles.error}>{errorFeedback}</span>}
                    </div>
                );
        }
    });

    return (
        <div className={styles.authentication}>
            <form onSubmit={onFormSubmit} id="authenticationForm">
                <h1>{isSignIn ? 'Zaloguj się' : 'Stwórz nowe konto'}</h1>
                {FieldsInputs}
                <div className={styles.toogler}>
                    <label htmlFor="checkbox">Pokaż hasło</label>
                    <input
                        id="checkbox"
                        type="checkbox"
                        checked={passwordIsShown}
                        onChange={()=>setPasswordIsShown(!passwordIsShown)}
                    />
                </div>
                <div className={styles.actions}>
                    <p>{isSignIn ? 'Nie masz jeszcze konta?' : 'Masz już konto?'}
                        <Link to={`?mode=${isSignIn ? 'signup' : 'signin'}`}>
                            {isSignIn ? 'Zarejestruj się!' : 'Zaloguj się'}
                        </Link>
                    </p>
                    <button
                        type="submit"
                        form="authenticationForm"
                        disabled={anyErrors.length > 0 || !nothingIsTouched}
                    >
                        {isSignIn ? 'Zaloguj' : 'Zarejestruj'}
                    </button>
                </div>
            </form>
        </div>
    )
}