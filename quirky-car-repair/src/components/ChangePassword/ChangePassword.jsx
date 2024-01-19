import styles from "./ChangePassword.module.css"
import {Button} from "../Button/Button.jsx";
import {useContext, useState} from "react";
import {useValidation} from "../../hooks/useValidation.jsx";
import {changePassword} from "../../api/userManage/changePassword.js";
import {AlertStateContext} from "../../context/AlertStateContext.js";
export function ChangePassword({id}){
    const [,setAlert] = useContext(AlertStateContext);
    const [passwordIsShown, setPasswordIsShown] = useState(false);
    const [formIsShown, setFormIsShown] = useState(false);
    const [passwords, setPasswords] = useState({});
    const [oldPassword, setOldPassword] = useState('');

    let errors = useValidation(passwords, false);
    const onChangeHandler = (e) =>{
        const key = e.target.name;
        const value = e.target.value;
        setPasswords(prevValues => ({ ...prevValues, [key]: value }));
    }
    const onFormSubmit = async (e) =>{
        e.preventDefault()
        const data = {oldPassword: oldPassword, newPassword: passwords.password, confirmPassword: passwords.confirmPassword};
        const response = await changePassword(id, data);

        if(response.success){
            Error({text: response.message, color: 'success'});
            setFormIsShown(false);
            setPasswords({});
            setOldPassword('');
        }else{
            Error({text: response.message, color: 'warning'});
        }
    }
    const Error = ({text, color}) => {
        setAlert({text: text, color: color})
        setTimeout(() => {
            setAlert();
        }, 3000);
    }
    return(
        <div className={styles.container}>
            <div className={styles.row}>
                <h3>Zmień hasło</h3>
                <input type="checkbox" className={styles.check} onChange={()=>setFormIsShown(!formIsShown)} checked={formIsShown} required/>
            </div>
            {formIsShown &&
                <form onSubmit={onFormSubmit}>
                    <div className={styles.column}>
                        <input
                            type={passwordIsShown ? "text" : "password"}
                            name="oldPassword"
                            placeholder="Podaj obecne hasło"
                            onChange={(e)=>setOldPassword(e.target.value)}
                            required
                        />
                    </div>
                    <div className={styles.column}>
                        <input
                            type={passwordIsShown ? "text" : "password"}
                            name="password"
                            placeholder="Podaj nowe hasło"
                            onBlur={onChangeHandler}
                            required
                        />
                        {errors.password && errors.password.isError && <span className={styles.error}>{errors.password.errorFeedback}</span>}
                    </div>
                    <div className={styles.column}>
                        <input
                            type={passwordIsShown ? "text" : "password"}
                            name="confirmPassword"
                            placeholder="Potwierdź nowe hasło"
                            onBlur={onChangeHandler}
                        />
                        {errors.confirmPassword && errors.confirmPassword.isError && <span className={styles.error}>{errors.confirmPassword.errorFeedback}</span>}
                    </div>
                    <div className={styles.row}>
                        <label htmlFor="checkbox">Pokaż hasło</label>
                        <input
                            id="checkbox"
                            type="checkbox"
                            checked={passwordIsShown}
                            onChange={()=>setPasswordIsShown(!passwordIsShown)}
                            className={styles.check}
                        />
                    </div>
                    <div className={styles.column}>
                        <Button color="orange" type="submit" width="w10">Zmień hasło</Button>
                    </div>
                </form>
            }
        </div>
    )
}