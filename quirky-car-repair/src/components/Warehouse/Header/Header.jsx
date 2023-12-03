import styles from "./Header.module.css";

export function Header({currentCategory, itemsCount}){

    return(
        <>
            <div className="row">
                <div className="col-12 d-flex align-items-center">
                    <h4>{currentCategory.name}</h4>
                    <span>({itemsCount} produkty)</span>
                </div>

            </div>
            <div className="row">
                <div className="col-12">
                    <ul className={styles.categoryPath}>
                        {/*{siblingCategories.map(({id, name}) => (*/}
                        <li className={styles.item}>ścieżka kategorii do zrobienia</li>
                        {/*))}*/}
                    </ul>
                </div>
            </div>
        </>
    )
}