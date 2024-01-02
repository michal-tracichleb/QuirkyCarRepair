import {useLoaderData} from "react-router-dom";
import {FlexContainer} from "../components/FlexContainer/FlexContainer.jsx";
import {Details} from "../components/Details/Details.jsx";
export function ProductDetails() {
    const product = useLoaderData();
    return(
        <FlexContainer>
            <Details product={product}/>
        </FlexContainer>
    )
}