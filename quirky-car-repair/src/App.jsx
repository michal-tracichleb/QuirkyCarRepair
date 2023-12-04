import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min";
import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import {NavBar} from "./components/NavBar/NavBar.jsx";
import {LoginModal} from "./components/LoginModal/LoginModal.jsx";
import {useEffect, useState} from "react";
import {Warehouse} from "./components/Warehouse/Warehouse.jsx";
import {ProductsPanel} from "./components/Warehouse/ProductsPanel/ProductsPanel.jsx";
import {CategoriesPanel} from "./components/Warehouse/CategoriesPanel/CategoriesPanel.jsx";
import {AlertStateContext} from "./context/AlertStateContext.js";
import {Alert} from "./components/Alert/Alert.jsx";

export default function App() {
    const [userIsLogged, setUserIsLogged] = useState(false);
    const [userData, setUserData] = useState({});
    const [alert, setAlert] = useState();

    useEffect(()=>{
        const sessionUserData = sessionStorage.user;

        if(sessionUserData){
            setUserData(JSON.parse(sessionUserData));
            setUserIsLogged(true);
        }
    },[userIsLogged]);

  return (
      <AlertStateContext.Provider value={[alert, setAlert]}>
          {alert && <Alert color={alert.color}>{alert.text}</Alert>}
          <Router>
              <NavBar userData={userData} userIsLogged={userIsLogged} setUserIsLogged={setUserIsLogged}/>
              {!userIsLogged && <LoginModal setUserIsLogged={setUserIsLogged}/>}
              <Routes>
                  <Route path="/" />
                  <Route
                      path="/warehouse"
                      element={<Warehouse />}
                  >
                      <Route index element={<CategoriesPanel />} />
                      <Route path=":categoryId" element={<ProductsPanel />} />
                  </Route>
                  <Route path="/serwis"/>
                  <Route path="/about"/>
                  <Route path="/kontakt"/>
                  <Route path="/user_profile"/>
              </Routes>
          </Router>
      </AlertStateContext.Provider>

  )
}
