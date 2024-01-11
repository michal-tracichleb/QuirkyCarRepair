import styles from "./CategoryMarginList.module.css";

export function CategoryMarginList({margins, categories, onMarginSelect}){
    return(
        <div className={styles.container}>
            {categories && categories.map((category) =>(
                <div className={styles.marginContainer} key={category.id}>
                    <div className={styles.margin}>
                        <h3>{category.name}</h3>
                    </div>
                    <div className={styles.toolbox}>
                        <select value={category.marginId === null ? 0 : category.marginId} onChange={(e)=>onMarginSelect(category.id, e.target.value)}>
                            <option value={0}>0</option>
                            {margins && margins.map((margin) =>(
                                <option value={margin.id} key={margin.id}>{margin.value} %</option>
                            ))}
                        </select>
                    </div>
                </div>
            ))}
        </div>
    )
}