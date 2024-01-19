import styles from "./UserList.module.css"
import {Link, useLoaderData} from "react-router-dom";
import {useContext, useEffect, useRef, useState} from "react";
import {AlertStateContext} from "../../context/AlertStateContext.js";

export function UserList(){
    const response = useLoaderData();
    const [users, setUsers] = useState([]);
    const [,setAlert] = useContext(AlertStateContext);
    const scroll = useRef();
    console.log(users)

    useEffect(()=>{
        if(response.success){
            setUsers(response.data);
        }else{
            Error({text: response.message, color: 'warning'})
        }
        if (scroll.current) {
            scroll.current.scrollIntoView({behavior: 'smooth'});
        }
    },[]);

    const Error = ({text, color}) => {
        setAlert({text: text, color: color})
        setTimeout(() => {
            setAlert();
        }, 3000);
    }

    return(
        <>
            <div ref={scroll}></div>
            <div className={styles.container}>
                {users && users.map((user) =>(
                    <Link to={`details/${user.userId}`} key={user.userId}>
                        <div className={styles.marginContainer} >
                            <div className={styles.margin}>
                                <h3>{user.firstName} {user.lastName}</h3>
                            </div>
                            <div className={styles.manage}>{user.roleName}</div>
                        </div>
                    </Link>
                ))}
            </div>
        </>
    )
}