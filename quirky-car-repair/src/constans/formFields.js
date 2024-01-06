export const formFields = {
    userName:{
        key: "userName",
        label: "Nazwa użytkownika",
        type: "text",
        placeholder: "Podaj nazwę użytkownika...",
    },
    email:{
        key: "email",
        label: "Email",
        type: "text",
        placeholder: "Podaj email...",
    },
    firstName:{
        key: "firstName",
        label: "Imię",
        type: "text",
        placeholder: "Podaj imię...",
    },
    lastName:{
        key: "lastName",
        label: "Nazwisko",
        type: "text",
        placeholder: "Podaj nazwisko...",
    },
    phoneNumber:{
        key: "phoneNumber",
        label: "Numer telefonu",
        type: "tel",
        placeholder: "Podaj numer telefonu...",
    },
    password:{
        key: "password",
        label: "Hasło",
        type: "password",
        placeholder: "Podaj hasło...",
    },
    confirmPassword:{
        key: "confirmPassword",
        label: "Potwierdź hasło",
        type: "password",
        placeholder: "Potwierdź hasło...",
    },

};
export const signInFields = { email: '', password: ''};
export const signInTouched = { email: false, password: false};

export const signUpFields = { userName:'', email:'', firstName:'', lastName:'', phoneNumber:'', password:'', confirmPassword:''};
export const signUpTouched = {userName:false, email:false, firstName:false, lastName:false, phoneNumber:false, password:false, confirmPassword:false};

