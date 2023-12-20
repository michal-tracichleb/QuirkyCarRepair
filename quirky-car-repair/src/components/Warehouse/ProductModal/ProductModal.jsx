import styles from "./ProductModal.module.css";
import {AddProductToCart} from "../../../utlis/AddProductToCart.js";

export function ProductModal({productData, Alert}){
    const lengthUnit=" mm.";
    const weightUnit=" kg.";
    return(
        <>
            <div className="modal fade" id="productModal" tabIndex="-1" aria-labelledby="productModalLabel" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h1 className="modal-title fs-5" id="productModalLabel">{productData.name}</h1>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">
                            {productData.description &&
                                <>
                                    <h6 data-bs-toggle="collapse" data-bs-target="#collapseDescription" aria-expanded="false" aria-controls="collapseDescription">Opis produktu:</h6>
                                    <div className="collapse" id="collapseDescription">
                                        <div className="card card-body">
                                            {productData.description}
                                        </div>
                                    </div>
                                </>
                            }
                            <h6 data-bs-toggle="collapse" data-bs-target="#collapseSpecyfication" aria-expanded="false" aria-controls="collapseSpecyfication">Informacje o produkcie:</h6>
                            <div className="collapse show" id="collapseSpecyfication">
                                <div className="card card-body">
                                    <div className={styles.row}>
                                        <div className={styles.title}>Producent</div>
                                        <div className={styles.data}>{productData.manufacturer ? productData.manufacturer : "-"}</div>
                                    </div>
                                    <div className={styles.row}>
                                        <div className={styles.title}>Model</div>
                                        <div className={styles.data}>{productData.model ? productData.model : "-"}</div>
                                    </div>
                                    <div className={styles.row}>
                                        <div className={styles.title}>Kod produktu</div>
                                        <div className={styles.data}>{productData.productCode ? productData.productCode : "-"}</div>
                                    </div>
                                    <div className={styles.row}>
                                        <div className={styles.title}>Kraj produkcji</div>
                                        <div className={styles.data}>{productData.countryOfOrigin ? productData.countryOfOrigin : "-"}</div>
                                    </div>
                                </div>
                            </div>
                            <h6 data-bs-toggle="collapse" data-bs-target="#collapseTechnicalData" aria-expanded="false" aria-controls="collapseTechnicalData">Dane techniczne:</h6>
                            <div className="collapse show" id="collapseTechnicalData">
                                <div className="card card-body">
                                    <div className={styles.row}>
                                        <div className={styles.title}>Wysokość</div>
                                        <div className={styles.data}>{productData.height ? productData.height + lengthUnit : "-"}</div>
                                    </div>
                                    <div className={styles.row}>
                                        <div className={styles.title}>Szerokość</div>
                                        <div className={styles.data}>{productData.width ? productData.width + lengthUnit: "-"}</div>
                                    </div>
                                    <div className={styles.row}>
                                        <div className={styles.title}>Głębokość</div>
                                        <div className={styles.data}>{productData.depth ? productData.depth + lengthUnit: "-"}</div>
                                    </div>
                                    <div className={styles.row}>
                                        <div className={styles.title}>Waga</div>
                                        <div className={styles.data}>{productData.weight ? productData.weight + weightUnit: "-"}</div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div className="modal-footer">
                            <h3 className={styles.price}>{productData.unitPrice} zł /szt.</h3>
                            <button className={styles.btn} data-bs-dismiss="modal" onClick={()=> {
                                AddProductToCart(productData.id, productData.name, productData.unitPrice);
                                Alert();
                            }}>Dodaj do koszyka</button>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}