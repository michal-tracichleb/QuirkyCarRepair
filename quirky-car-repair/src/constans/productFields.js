export const productFields = {
    name:{
        key: "name",
        label: "Nazwa produktu",
        type: "text",
        required: true,
    },
    manufacturer:{
        key: "manufacturer",
        label: "Producent",
        type: "text",
        required: false,
    },
    model:{
        key: "model",
        label: "Model",
        type: "text",
        required: false,
    },
    productCode:{
        key: "productCode",
        label: "Kod produktu",
        type: "text",
        required: false,
    },
    countryOfOrigin:{
        key: "countryOfOrigin",
        label: "Kraj produkcji",
        type: "text",
        required: false,
    },
    partCategoryId:{
        key: "partCategoryId",
        label: "Kategoria produktu",
        type: "select",
        required: true,
    },
    description:{
        key: "description",
        label: "Opis produktu",
        type: "textarea",
        required: false,
    },
    quantity:{
        key: "quantity",
        label: "Ilość",
        type: "number",
        required: true,
    },
    minimumQuantity:{
        key: "minimumQuantity",
        label: "Ilość minimalna",
        type: "number",
        required: false,
    },
    unitType:{
        key: "unitType",
        label: "Typ jednostki",
        type: "text",
        required: true,
    },
    unitPrice:{
        key: "unitPrice",
        label: "Cena",
        type: "number",
        required: true,
    },
    weight:{
        key: "weight",
        label: "Waga",
        type: "number",
        required: false,
    },
    height:{
        key: "height",
        label: "Wysokość",
        type: "number",
        required: false,
    },
    width:{
        key: "width",
        label: "Szerokość",
        type: "number",
        required: false,
    },
    depth:{
        key: "depth",
        label: "Głębokość",
        type: "number",
        required: false,
    },
};