import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min";
import {NavBar} from "./components/NavBar/NavBar.jsx";
import {LoginModal} from "./components/LoginModal/LoginModal.jsx";
import {useEffect, useState} from "react";
export default function App() {
    const [userIsLogged, setUserIsLogged] = useState(false);
    const [userData, setUserData] = useState({});

    useEffect(()=>{
        const sessionUserData = sessionStorage.user;

        if(sessionUserData){
            setUserData(JSON.parse(sessionUserData));
            setUserIsLogged(true);
        }
    },[userIsLogged]);

  return (
    <>
        <NavBar userData={userData} userIsLogged={userIsLogged}/>
        {!userIsLogged && <LoginModal setUserIsLogged={setUserIsLogged}/>}
    </>
  )
}
