import styles from "./ProductManage.module.css";
import {FlexContainer} from "../FlexContainer/FlexContainer.jsx";
import {productFields} from "../../constans/productFields.js";
import {Form, useLoaderData, useSearchParams} from "react-router-dom";
import {useContext, useEffect, useState} from "react";
import {SearchBar} from "../SearchBar/SearchBar.jsx";
import {saveNewProduct} from "../../api/saveNewProduct.js";
import {productLoader} from "../../api/productLoader.js";
import {saveModifiedProduct} from "../../api/saveModifiedProduct.js";
import {AlertStateContext} from "../../context/AlertStateContext.js";
export function ProductManage(){
    const categories = useLoaderData();
    const [searchParams] = useSearchParams();
    const productId = searchParams.get('id');
    const [product, setProduct] = useState();
    const [, setAlert] = useContext(AlertStateContext);
    const credentialsKeys = Object.keys(productFields);

    useEffect(() => {
        if(productId){
            const loaderParams = {
                params: {
                    productId: productId,
                },
            };
            productLoader(loaderParams)
                .then((data) => {
                    setProduct(data);
                });
        }
    }, [productId]);

    const inputChangeHandler = (e) =>{
        const key = e.target.name;
        const value = e.target.value;
        setProduct(prevValues => ({ ...prevValues, [key]: value }));
    }
    const onCategorySelect = (value) =>{
        setProduct(prevValues => ({ ...prevValues, 'partCategoryId': value }));
    }

    const onFormSubmit = async (e) =>{
        e.preventDefault();
        let response;
        if(productId){
             response = await saveModifiedProduct(product);
        }else{
             response = await saveNewProduct(product);
        }

        setAlert({text: response.message, color: response.success ? 'success' : 'warning'});
        setTimeout(() => {
            setAlert();
        }, 3000);
    }
    const fields = credentialsKeys.map(key =>{
        const input = productFields[key];
        const value = product && product[key] ? product[key] : '';
        switch (input.type){
            case 'text':
            case 'number':
                return(
                    <tr key={key}>
                        <td><label htmlFor={key}>{input.label}</label></td>
                        <td><input
                            type={input.type}
                            name={key}
                            value={value}
                            onChange={inputChangeHandler}
                            required={input.required}
                        /></td>
                    </tr>
                )
            case 'select':
                return(
                    <tr key={key}>
                        <td><label htmlFor={key}>{input.label}</label></td>
                        <td>
                            <SearchBar list={categories} itemToDisplay={'name'} callback={onCategorySelect} required={input.required} value={value}/>
                        </td>
                    </tr>
                )
            case 'textarea':
                return(
                    <tr key={key}>
                        <td><label htmlFor={key}>{input.label}</label></td>
                        <td>
                            <textarea
                                name={key}
                                value={value}
                                onChange={inputChangeHandler}
                            />
                        </td>
                    </tr>
                )
        }

    })
    return(
        <FlexContainer>
            <Form onSubmit={onFormSubmit} className={styles.form}>
                <table className={styles.productTable}>
                    <tbody>
                    {fields}
                    </tbody>
                </table>
                <button type="submit">Zapisz i wyślij</button>
            </Form>
        </FlexContainer>

    )
}