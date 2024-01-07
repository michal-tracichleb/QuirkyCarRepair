import "./styles/theme.css"
import "./styles/globals.css"
import React from 'react'
import ReactDOM from 'react-dom/client'
import {createBrowserRouter, RouterProvider} from "react-router-dom";
import {MainPage} from "./views/MainPage.jsx";
import {Layout} from "./components/Layout/Layout.jsx";
import {Contact} from "./views/Contact.jsx";
import {About} from "./views/About.jsx";
import {Warehouse} from "./views/Warehouse.jsx";
import {CategoriesPanel} from "./components/CategoriesPanel/CategoriesPanel.jsx";
import {ProductsPanel} from "./components/Warehouse/ProductsPanel/ProductsPanel.jsx";
import {Authentication} from "./components/Authentication/Authentication.jsx";
import {ProductDetails} from "./views/ProductDetails.jsx";
import {productLoader} from "./api/productLoader.js";
import {ProductManage} from "./components/ProductManage/ProductManage.jsx";
import {categoriesLoader} from "./api/categoriesLoader.js";
import {Delivery} from "./components/Delivery/Delivery.jsx";
import {getAllProducts} from "./api/getAllProducts.js";
import {Orders} from "./components/Orders/Orders.jsx";
import {OrderDetails} from "./components/OrderDetails/OrderDetails.jsx";

const router = createBrowserRouter([
    {
        path: '',
        element: <Layout/>,
        children:[
            {
                path: '/',
                element: <MainPage/>,
            },
            {
                path: '/warehouse',
                element: <Warehouse/>,
                children:[
                    {
                        path: '/warehouse',
                        element: <CategoriesPanel/>,
                    },
                    {
                        path: ':categoryId',
                        element: <ProductsPanel/>,
                    },
                    {
                        path: ':categoryId/product/:productId',
                        element: <ProductDetails/>,
                        loader: productLoader,
                    },
                    {
                        path: 'product/manage',
                        element: <ProductManage/>,
                        loader: categoriesLoader,
                    },
                    {
                        path: 'delivery',
                        element: <Delivery/>,
                        loader: getAllProducts,
                    },
                    {
                        path: 'orders',
                        element: <Orders/>
                    },
                    {
                        path: 'details/:orderId',
                        element: <OrderDetails/>
                    },
                ]
            },
            {
                path: '/contact',
                element: <Contact/>,
            },
            {
                path: '/about',
                element: <About/>,
            },
            {
                path: '/authentication',
                element: <Authentication/>,
            },
        ]
    }
])

ReactDOM.createRoot(document.getElementById('root')).render(
    <RouterProvider router={router}></RouterProvider>
)
