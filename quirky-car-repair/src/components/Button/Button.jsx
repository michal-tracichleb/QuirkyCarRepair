import styles from "./Button.module.css"
export function Button({onClick, type = "button", disabled, name, children, color, width, form}){
    return(
        <button
            type={type}
            onClick={onClick}
            disabled={disabled}
            name={name}
            form={form}
            className={`${styles.btn} ${color ? styles[color] : ''} ${width ? styles[width] : ''}`}
        >
            {children}
        </button>
    )
}