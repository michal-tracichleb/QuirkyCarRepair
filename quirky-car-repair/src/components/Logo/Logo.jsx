import styles from "./Logo.module.css";
import img from "../../assets/Logo_1.jpg";
import {Link} from "react-router-dom";

export function Logo(){
    return(
        <div className={styles.logo}>
            <Link to="/">
                <img src={img} alt="logo"/>
                <h1>QuirkyCarRepair</h1>
            </Link>
        </div>

    )
}