import styles from "./NewServiceOrder.module.css"
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css"
import "react-datepicker/dist/react-datepicker.js"
import {useContext, useEffect, useState} from "react";
import {UserStateContext} from "../../context/UserStateContext.js";
import {AlertStateContext} from "../../context/AlertStateContext.js";
import {SearchBar} from "../SearchBar/SearchBar.jsx";
import {vehicleBrands} from "../../constans/vehicleBrands.js";
import PhoneNumberInput from "../PhoneNumberInput/PhoneNumberInput.jsx";
import {createServiceOrder} from "../../api/createServiceOrder.js";
import {useNavigate} from "react-router-dom";
import {format} from 'date-fns';
import {getAllVehicles} from "../../api/getAllVehicles.js";
import {getUserDetails} from "../../api/getUserDetails.js";
export function NewServiceOrder(){
    const navigate = useNavigate();
    const [userData] = useContext(UserStateContext);
    const [,setAlert] = useContext(AlertStateContext);
    const managementPermissions = userData.role.toLocaleLowerCase() === 'admin' || userData.role.toLocaleLowerCase() === 'mechanic';
    const [errors, setErrors] = useState();
    const [date, setDate] = useState();
    const [vehicles, setVehicles] = useState([]);
    const [vehicleData, setVehicleData] = useState();
    const [user, setUser] = useState();
    const [orderDescription, setOrderDescription] = useState('');

    useEffect(() => {
        fetchVehicles()
        if(!managementPermissions){
            fetchUserDetails(userData.id);
        }
    }, []);

    const fetchVehicles = async () =>{
        let response
        if(managementPermissions){
            response = await getAllVehicles();
        }

        if(response.success){
            setVehicles(response.data);
        }else{
            Error({text: response.message, color: 'warning'})
        }
    }
    const fetchUserDetails = async (id) =>{
        const response = await getUserDetails(id)

        if(response.success){
            setUser(response.data);
        }else{
            Error({text: response.message, color: 'warning'})
        }
    }
    const isWeekend = (date) => {
        const day = date.getDay();
        return day !== 0 && day !== 6;
    };
    const onVehicleSelect = (id) =>{
        const vehicle = vehicles.find(vehicle => vehicle.id === id);
        setVehicleData(vehicle);
    }
    const onBrandChange = (value) =>{
        setVehicleData(prevValues => ({ ...prevValues, brand: value }));
    }
    const onVehicleDataChange = (e) =>{
        const key = e.target.name;
        let value = e.target.value;
        setVehicleData(prevValues => ({ ...prevValues, [key]: value }));
    }
    const onUserDataChange = (e) =>{
        const key = e.target.name;
        let value = e.target.value;
        setUser(prevValues => ({ ...prevValues, [key]: value }));
    }
    const validateForm = ()=>{
        let valid = true;
        const newErrors = {};
        if(!date){
            newErrors.date = "Proszę wybrać termin usługi";
            valid = false;
        }
        if(!vehicleData.brand || !vehicleData.model || !vehicleData.year || !vehicleData.plateNumber || vehicleData.vin.trim().length !== 17){
            newErrors.vehicleData = "Proszę wprowadzić poprawne dane pojazdu";
            valid = false;
        }
        if(!user.firstName || !user.lastName || !user.phoneNumber){
            newErrors.userData = "Proszę wprowadzić dane zamawiającego";
            valid = false;
        }
        setErrors(newErrors);
        return valid;
    }
    const onSubmit = async (e) =>{
        e.preventDefault();

        if (validateForm()) {
            const data = {
                dateStartRepair: format(date, 'yyyy-MM-dd'),
                orderDescription:orderDescription,
                userId: user.id ? user.id : 0,
                firstName: user.firstName,
                lastName: user.lastName,
                phoneNumber: user.phoneNumber,
                vehicleId: vehicleData.id ? vehicleData.id : 0,
                vin: vehicleData.vin,
                plateNumber: vehicleData.plateNumber,
                brand: vehicleData.brand,
                model: vehicleData.model,
                year: vehicleData.year
            }
            const response = await createServiceOrder(data)
            if(response.success){
                navigate(`/service/orders/details/${response.data.serviceOrderId}`)
            }else{
                Error({text: response.message, color: 'warning'})
            }
        }else{
            Error({text:'Formularz zawiera błędy. Popraw je przed wysłaniem.', color:'warning'})
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
            <div className={styles.header}>
                <h1>Zamów usługę</h1>
                <p>
                    Wypełnij formularz, wskazując preferowany przez Ciebie termin realizacji usługi. Nasz serwisant potwierdzi wybrany przez Ciebie termin lub zaproponuje inny.
                </p>
                <p>
                    Prosimy o precyzyjne opisanie oczekiwanych usług lub występujących usterek.
                </p>
            </div>
            <form onSubmit={onSubmit}>
                <div className={styles.input_container}>
                    <h2>Preferowany termin realizacji</h2>
                    <div>
                        <DatePicker
                            minDate={new Date()}
                            selected={date}
                            onChange={(date) => setDate(date)}
                            filterDate={isWeekend}

                        />
                    </div>
                    {errors && errors.date && <p className={styles.error}>{errors.date}</p>}
                </div>
                <div className={styles.input_container}>
                    <h2>Dane pojazdu</h2>
                    <p>Wyszukaj numer rejestracyjny</p>
                    <SearchBar list={vehicles} itemToDisplay="plateNumber" callback={onVehicleSelect}/>

                    <div className={styles.wrapper}>
                        <SearchBar
                            list={vehicleBrands}
                            value={vehicleData && vehicleData.brand ? vehicleData.brand : null}
                            callback={onBrandChange}
                            itemToDisplay="name"
                            returnValue="name"
                            required
                        />
                        <input
                            name="model"
                            placeholder="Model"
                            value={vehicleData && vehicleData.model ? vehicleData.model : ''}
                            onChange={onVehicleDataChange}
                        />
                    </div>

                    <div className={styles.wrapper}>
                        <DatePicker
                            maxDate={new Date()}
                            selected={vehicleData && vehicleData.year ? new Date(vehicleData.year, 0, 1) : null}
                            onChange={(date)=>setVehicleData(prevValues => ({ ...prevValues, year: date.getFullYear()}))}
                            showYearPicker
                            dateFormat="yyyy"
                            required
                        />
                        <input
                            name="plateNumber"
                            placeholder="Numer rejestracyjny"
                            value={vehicleData && vehicleData.plateNumber ? vehicleData.plateNumber : ''}
                            onChange={onVehicleDataChange}
                        />
                    </div>
                    <div className={styles.wrapper}>
                        <input
                            name="vin"
                            placeholder="VIN"
                            value={vehicleData && vehicleData.vin ? vehicleData.vin : ''}
                            onChange={onVehicleDataChange}
                            required
                        />
                    </div>
                    {errors && errors.vehicleData && <p className={styles.error}>{errors.vehicleData}</p>}
                </div>
                <div className={styles.input_container}>
                    <h2>Informacje dla serwisanta</h2>
                    <textarea
                        name="OrderDescription"
                        value={orderDescription}
                        onChange={(e)=>setOrderDescription(e.target.value)}
                        required
                    />
                </div>
                <div className={styles.input_container}>
                    <h2>Dane zamawiającego</h2>
                    <div className={styles.wrapper}>
                        <input name="firstName"
                               placeholder="Imię"
                               value={user && user.firstName ? user.firstName : ''}
                               onChange={onUserDataChange}
                               required
                        />
                        <input
                            name="lastName"
                            placeholder="Nazwisko"
                            value={user && user.lastName ? user.lastName : ''}
                            onChange={onUserDataChange} required
                        />
                    </div>
                    <div className={styles.wrapper}>
                        <PhoneNumberInput
                            onChange={onUserDataChange}
                            value={user && user.phoneNumber ? user.phoneNumber : ''}
                            required
                        />
                    </div>
                    {errors && errors.userData && <p className={styles.error}>{errors.userData}</p>}
                </div>
                <div className={styles.footer}>
                    <button type="submit">Wyślij</button>
                </div>
            </form>
        </div>
    )
}