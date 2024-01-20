import styles from "./VehicleRegistration.module.css"
import DatePicker from "react-datepicker"
import "react-datepicker/dist/react-datepicker.css"
import {SearchBar} from "../SearchBar/SearchBar.jsx";
import {vehicleBrands} from "../../constans/vehicleBrands.js";
import {useContext, useState} from "react";
import {saveNewVehicle} from "../../api/service/saveNewVehicle.js";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import {Button} from "../Button/Button.jsx";
export function VehicleRegistration(){
    const [vehicleData, setVehicleData] = useState({brand:'', model:'', vin:'', year:null, plateNumber:''});
    const [,setAlert] = useContext(AlertStateContext);
    const brandCallback = (value) =>{
        setVehicleData(prevValues => ({ ...prevValues, brand: value }));
    }
    const onYearChange = (value) =>{
        setVehicleData(prevValues => ({ ...prevValues, year: value}));
    }
    const onInputChange = (e) =>{
        const key = e.target.name;
        let value = e.target.value;
        setVehicleData(prevValues => ({ ...prevValues, [key]: value }));
    }
    const editVehicleData = (data) => {
        data.year = data.year.getFullYear();
        return data;
    };
    const handleSubmit = async (e) =>{
        e.preventDefault();
        let valid = true;

        if(!vehicleData.brand || !vehicleData.model || !vehicleData.year || !vehicleData.plateNumber || vehicleData.vin.trim().length !== 17){
            valid = false;
            Error({text: "Wystąpił błąd. Sprawdź dane pojazdu", color: "warning"})
        }

        if(valid){
            const data = editVehicleData(vehicleData)
            const response = await saveNewVehicle(data);
            Error({text: response.message, color: response.success ? "success" : "dangerous"})
        }
    }
    const Error = ({text, color}) =>{
        setAlert({text: text, color: color})
        setTimeout(() => {
            setAlert();
        }, 3000);
    }
    return(
        <div className={styles.container}>
            <form onSubmit={handleSubmit}>
                <h1>Dodaj swój pojazd</h1>
                <div className={styles.input_container}>
                    <label>Marka pojazdu</label>
                    <SearchBar list={vehicleBrands} value={null} itemToDisplay="name" callback={brandCallback} returnValue="name" required/>
                </div>
                <div className={styles.input_container}>
                    <label>Model pojazdu</label>
                    <input type="text" name="model" required onChange={onInputChange}/>
                </div>
                <div className={styles.input_container}>
                    <label>VIN</label>
                    <input type="text" name="vin" required onChange={onInputChange}/>
                </div>
                <div className={styles.input_container}>
                    <label>Rok produkcji</label>
                    <DatePicker
                        selected={vehicleData.year}
                        onChange={(date) => onYearChange(date)}
                        maxDate={new Date()}
                        showYearPicker
                        dateFormat="yyyy"
                        required
                    />
                </div>
                <div className={styles.input_container}>
                    <label>Numer rejestracyjny</label>
                    <input type="text" name="plateNumber" required onChange={onInputChange}/>
                </div>
                <div className={styles.input_container}>
                    <Button type="submit" width="w100" color="orange">Zapisz i wyślij</Button>
                </div>
            </form>
        </div>
    )
}