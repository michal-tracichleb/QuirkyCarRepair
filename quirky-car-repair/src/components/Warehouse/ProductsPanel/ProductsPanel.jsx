import {useParams} from "react-router-dom";
import {useEffect, useState, useContext, useRef} from "react";
import axios from "axios";
import {SideBar} from "../../SideBar/SideBar.jsx";
import {CategoriesList} from "../CategoryList/CategoriesList.jsx";
import {Header} from "../Header/Header.jsx";
import {ProductsList} from "../ProductsList/ProductsList.jsx";
import {AlertStateContext} from "../../../context/AlertStateContext.js";
import {Pagination} from "../../Pagination/Pagination.jsx";
import {PaginationSmall} from "../../PaginationSmall/PaginationSmall.jsx";

export function ProductsPanel (){
    const { categoryId } = useParams();
    const { pageId } = useParams();
    const [isLoading, setIsLoading] = useState(true);
    const [currentCategory, setCurrentCategory] = useState({});
    const [subcategories, setSubcategories] = useState([]);
    const [siblingCategories, setSiblingCategories] = useState([]);
    const [productsData, setProductsData] = useState([]);
    const [alert, setAlert] = useContext(AlertStateContext);
    const scroll = useRef();

    useEffect(() => {
        fetchCategoriesData();
        fetchProductsData();
        setIsLoading(false);

        if (scroll.current) {
            scroll.current.scrollIntoView({ behavior: 'smooth' });
        }
    }, [categoryId, pageId]);

    const fetchCategoriesData = async () => {
            try {
                const response = await axios.get(`https://localhost:7247/api/Warehouse/GetPartCategoryStructure?id=${categoryId}`);
                prepareCategories(response.data);
            } catch (error) {
                Error();
            }
    };
    const fetchProductsData = async () => {
        const body = {"categoryId": categoryId, "page": pageId, "pageSize": 10}
        try {
            const response = await axios.post(`https://localhost:7247/api/Warehouse/GetPartsPage`, body);
            setProductsData(response.data);
        } catch (error) {
            Error();
        }
    };
    const prepareCategories=(data)=>{
        setSubcategories(data.subcategories);
        setCurrentCategory({'id': data.id, 'name': data.name, 'parentCategory': data.parentCategory});
        setSiblingCategories(data.siblingCategories);
    };

    const Error=()=>{
        setAlert({color:'danger', text: 'Błąd podczas pobierania danych, proszę odświeżyć stronę'})
        setTimeout(() => {
            setAlert();
        }, 3000);
    }

    if(isLoading){
        return(<p>ladowanie</p>)
    }

    return (
        <>
                <div ref={scroll}></div>
                <div className="container m-0 p-0">
                    <Header currentCategory={currentCategory} itemsCount={productsData.itemCount}/>
                    <div className="row">
                        <div className="col-3">
                            <SideBar listFunction={<CategoriesList categories={subcategories}/>}>Podkategorie</SideBar>
                        </div>
                        <div className="col-9 bg-white p-4" >
                            {productsData.itemCount < 1 ?
                                <div className="row text-center">
                                    <h2>Brak produktów w kategorii</h2>
                                </div>
                            :
                                <>
                                    <div className="row d-inline float-end mb-3">
                                        <PaginationSmall pageId={pageId} pageCount={productsData.pageCount} path={`/warehouse/${categoryId}`}/>
                                    </div>
                                    <div className="row d-inline">
                                        <ProductsList productsData={productsData.items}/>
                                    </div>
                                    <div className="row d-inline float-end mt-2">
                                        <Pagination pageId={pageId} pageCount={productsData.pageCount} path={`/warehouse/${categoryId}`}/>
                                    </div>
                                </>
                            }
                        </div>
                    </div>
                </div>
        </>
    );
}