import styles from "./ProductsPanel.module.css"
import {Link, useParams, useSearchParams} from "react-router-dom";
import {useEffect, useState, useRef, useContext} from "react";
import axios from "axios";
import {ProductsList} from "../ProductsList/ProductsList.jsx";
import {Pagination} from "../../Pagination/Pagination.jsx";
import {PaginationSmall} from "../../PaginationSmall/PaginationSmall.jsx";
import {Container} from "../../ContentLayout/Container/Container.jsx";
import {Sidebar} from "../../ContentLayout/Sidebar/Sidebar.jsx";
import {MainContent} from "../../ContentLayout/MainContent/MainContent.jsx";
import {BACK_END_URL} from "../../../constans/backEndUrl.js";
import {ProductManageLink} from "../../ProductManageLink/ProductManageLink.jsx";
import {UserStateContext} from "../../../context/UserStateContext.js";
import {AlertStateContext} from "../../../context/AlertStateContext.js";
import {removeProduct} from "../../../api/removeProduct.js";

export function ProductsPanel (){
    const { categoryId } = useParams();
    const [searchParams] = useSearchParams();
    const pageId = searchParams.get('page');

    const [userData] = useContext(UserStateContext);
    const [,setAlert] = useContext(AlertStateContext)
    const managementPermissions = userData.role.toLocaleLowerCase() === ('admin' || 'storekeeper');

    const [currentCategory, setCurrentCategory] = useState({});
    const [subcategories, setSubcategories] = useState([]);
    const [siblingCategories, setSiblingCategories] = useState([]);
    const [productsData, setProductsData] = useState([]);
    const scroll = useRef();
    const [subnav, setSubnav] = useState(false);

    const showSubnav = () => setSubnav(!subnav);

    useEffect(() => {
        fetchCategoriesData();
        fetchProductsData();

        if (scroll.current) {
            scroll.current.scrollIntoView({ behavior: 'smooth' });
        }
    }, [categoryId, pageId]);

    const fetchCategoriesData = async () => {
            try {
                const response = await axios.get(`${BACK_END_URL}/Warehouse/GetPartCategoryStructure?id=${categoryId}`);
                prepareCategories(response.data);
            } catch (error) {
                console.log(error)
            }
    };
    const fetchProductsData = async () => {
        const body = {"categoryId": categoryId, "page": pageId, "pageSize": 10}
        try {
            const response = await axios.post(`${BACK_END_URL}/Warehouse/GetPartsPage`, body);
            setProductsData(response.data);
        } catch (error) {
            console.log(error)
        }
    };
    const prepareCategories=(data)=>{
        setSubcategories(data.subcategories);
        setCurrentCategory({'id': data.id, 'name': data.name, 'parentCategory': data.parentCategory});
        setSiblingCategories(data.siblingCategories);
    };

    const HandleRemoveProduct = async  (id) =>{
        const userConfirmed = window.confirm('Czy na pewno chcesz usunąć ten produkt?');

        if(userConfirmed) {
            const response = await removeProduct(id);
            if(response.success){
                setAlert({text: response.message, color: 'success'});

                const updatedProducts = [...productsData.items];
                const filteredProducts = updatedProducts.filter((product) => product.id !== id);
                setProductsData(prevValues => ({ ...prevValues, items: filteredProducts }));
            }else{
                setAlert({text: response.message, color: 'warning'});
            }
            setTimeout(() => {
                setAlert();
            }, 3000);
        }
    }

    return (
        <>
            <div ref={scroll}></div>
            <Container>
                <Sidebar>
                    <a className={styles.SidebarLink} onClick={showSubnav}>
                        <span className={styles.SidebarLabel}>Podkategorie</span>
                    </a>
                    {subnav && subcategories.map((subcategory) => (
                        <Link to={`/warehouse/${subcategory.id}?page=1`} key={subcategory.id} className={styles.DropdownLink}>
                            <span className={styles.SidebarLabel}>{subcategory.name}</span>
                        </Link>
                        ))

                    }
                </Sidebar>
                <MainContent>
                    {managementPermissions &&
                        <div className={styles.toolbox}>
                            <ProductManageLink to="/warehouse/product/manage">Dodaj</ProductManageLink>
                        </div>
                    }

                    <PaginationSmall pageId={pageId} pageCount={productsData.pageCount} path={`/warehouse/${categoryId}`}/>

                    <ProductsList productsData={productsData.items} removeAction={HandleRemoveProduct}/>

                    <Pagination pageId={pageId} pageCount={productsData.pageCount} path={`/warehouse/${categoryId}`}/>

                </MainContent>
            </Container>
        </>
    );
}