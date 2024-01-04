import {useEffect, useState} from "react";

function validateInput(key, value, isSignIn, secondValue){
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    const passwordRegex = /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/;

    switch (key) {
        case 'userName':
            const nameValidation = value.trim().length < 6;
            const nameFeedback = 'Nazwa użytkownika musi zawierać 6 znaków!';

            return [nameValidation, nameFeedback];
        case 'email':
            const emailValidation = value.trim().match(emailRegex);
            const emailFeedback = 'Proszę wprowadzić poprawny adres email!';

            return [!emailValidation, emailFeedback];
        case 'firstName':
            const firstNameValidation = value.trim().length > 0;
            const firstNameFeedback = 'Proszę podać imię!';

            return [!firstNameValidation, firstNameFeedback];
        case 'lastName':
            const lastNameValidation = value.trim().length > 0;
            const lastNameFeedback = 'Proszę podać nazwisko!';

            return [!lastNameValidation, lastNameFeedback];
        case 'phoneNumber':
            const phoneNumberValidation = value.length === 12;
            const phoneNumberFeedback = 'Proszę wprowadzić poprawny numer telefonu!';
            return [!phoneNumberValidation, phoneNumberFeedback];
        case 'password':
            if(isSignIn){
                const passwordValidation = value.trim().length > 0;
                const passwordFeedback = 'Proszę podać hasło!';
                return [!passwordValidation, passwordFeedback];
            }else{
                const passwordValidation = value.trim().match(passwordRegex);
                const passwordFeedback = 'Hasło powinno zawierać: 8 znaków, wielką literę, małą literę, cyfrę oraz znak specjalny!';
                return [!passwordValidation, passwordFeedback];
            }
        case 'confirmPassword':
            const confirmPasswordValidation = secondValue && value.trim() === secondValue.trim();
            const confirmPasswordFeedback = 'Hasła nie są identyczne!';

            return [!confirmPasswordValidation, confirmPasswordFeedback];
        default:
            return [true, 'Nieznany błąd, proszę spróbować później.'];
    }
}
export function useValidation (inputs, touchedFields, isSignIn){
    const [errors, setErrors] = useState({});
    useEffect(() => {
        const inputsKeys = Object.keys(inputs);

        const errorsInitial = {};

        inputsKeys.forEach(key => {
            errorsInitial[key] = { isError: false, errorFeedback: '' };
        });

        setErrors(errorsInitial);
    }, []);

    useEffect(() => {
        const inputsEntries = Object.entries(inputs);
        let secondValue = '';
        inputsEntries.forEach(input => {
            const [key, value] = input;

            if (key === "password") {
                secondValue = value;
            }
            const timeout = setTimeout(() => {
                const [isError, errorFeedback] = validateInput(key, value, isSignIn, secondValue);

                setErrors(prevErrors => ({
                    ...prevErrors,
                    [key]: { isError, errorFeedback },
                }));
            }, 500);
            return () => {
                clearTimeout(timeout);
            };

        });
    }, [inputs, touchedFields]);

    return errors;
}
