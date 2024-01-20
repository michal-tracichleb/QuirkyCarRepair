import styles from "./UserDetails.module.css"
import {useParams} from "react-router-dom";
import {useContext, useEffect, useState} from "react";
import {getUserDetails} from "../../api/userManage/getUserDetails.js";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import {UserStateContext} from "../../context/UserStateContext.js";
import {Button} from "../Button/Button.jsx";
import PhoneNumberInput from "../PhoneNumberInput/PhoneNumberInput.jsx";
import {useValidation} from "../../hooks/useValidation.jsx";
import {ChangePassword} from "../ChangePassword/ChangePassword.jsx";
import {editUserData} from "../../api/userManage/editUserData.js";
import {getRoles} from "../../api/userManage/getRoles.js";
import {editUserRole} from "../../api/userManage/editUserRole.js";

export function UserDetails(){
    const { userId } = useParams();
    const [,setAlert] = useContext(AlertStateContext);
    const [user] = useContext(UserStateContext);
    const [userData, setUserData] = useState([]);
    const [roles, setRoles] = useState([]);
    const isAdmin = user.role.toLowerCase() === 'admin';
    let errors = useValidation(userData, false);

    useEffect(()=>{
        fetchUserData();
        if(isAdmin){
            fetchRoles();
        }
    },[]);

    const fetchUserData = async () =>{
        const response = await getUserDetails(Number(userId));

        if(response.success){
            setUserData(response.data);
        }else{
            Error({text: response.message, color: 'warning'})
        }
    }
    const fetchRoles = async () =>{
        const response = await getRoles();

        if(response.success){
            setRoles(response.data);
        }else{
            Error({text: response.message, color: 'warning'})
        }
    }
    const onChangeHandler = (e) =>{
        const key = e.target.name;
        const value = e.target.value;
        setUserData(prevValues => ({ ...prevValues, [key]: value }));
    }
    const onRoleChangeHandler = async (e) =>{
        const value = e.target.value;
        const response = await editUserRole(userData.userId, value);

        if(response.success){
            Error({text: response.message, color: 'success'});
            setUserData(prevValues => ({ ...prevValues, roleId: value }));
        }else{
            Error({text: response.message, color: 'warning'})
        }
    }
    const onFormSubmit = async (e) =>{
        e.preventDefault();
        const response = await editUserData(userId, userData);
        if(response.success){
            setUserData(response.data)
            Error({text: response.message, color: 'success'});
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

    if(Number(user.id) !== Number(userId) && !isAdmin){
        return(<h1>Odmowa dostępu</h1>)
    }

    return(
        <>
            <div className={styles.container}>
                <h1>Edytuj dane osobowe</h1>
                <form onSubmit={onFormSubmit}>
                    {isAdmin &&
                        <div className={styles.row}>
                            <label>Rola</label>
                            <select name="role" onChange={onRoleChangeHandler} value={userData.roleId}>
                                {roles.map((role)=> (
                                    <option key={role.id} value={role.id}>{role.name}</option>
                                ))}
                            </select>
                        </div>
                    }
                    <div className={styles.row}>
                        <div>
                            <input type="text" name="firstName" placeholder="Imię" value={userData.firstName ? userData.firstName : ''} onChange={onChangeHandler}/>
                            {errors.firstName && errors.firstName.isError && <span className={styles.error}>{errors.firstName.errorFeedback}</span>}
                        </div>
                        <div>
                            <input type="text" name="lastName" placeholder="Nazwisko" value={userData.lastName ? userData.lastName : ''} onChange={onChangeHandler}/>
                            {errors.lastName && errors.lastName.isError && <span className={styles.error}>{errors.lastName.errorFeedback}</span>}
                        </div>
                    </div>
                    <div className={styles.row}>
                        <div>
                            <input type="text" name="email" placeholder="email" value={userData.email ? userData.email : ''} onChange={onChangeHandler}/>
                            {errors.email && errors.email.isError && <span className={styles.error}>{errors.email.errorFeedback}</span>}
                        </div>
                        <div>
                            <PhoneNumberInput value={userData.phoneNumber ? userData.phoneNumber : ''} onChange={onChangeHandler}/>
                            {errors.phoneNumber && errors.phoneNumber.isError && <span className={styles.error}>{errors.phoneNumber.errorFeedback}</span>}
                        </div>
                    </div>
                    <div className={styles.row}>
                        <Button color="blue" type="submit">Zapisz</Button>
                    </div>
                </form>
                {Number(user.id) === Number(userId) &&
                    <ChangePassword id={user.id}/>
                }
            </div>
        </>
    )
}