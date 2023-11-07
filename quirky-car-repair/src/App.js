import React, { useRef, useState, useEffect } from "react";
import './css/App.css';
import NavBar from "./js/components/NavBar";

export default function App() {
    /* User data section */
    const [userIsLogged, setUserIsLogged] = useState(false);
    const [userData, setUserData] = useState([]);
  return (
      <div id="App">
          <NavBar
              userIsLogged={userIsLogged}
              setUserIsLogged={setUserIsLogged}
              userData={userData}
              setUserData={setUserData}
          />

      </div>
  );
}
