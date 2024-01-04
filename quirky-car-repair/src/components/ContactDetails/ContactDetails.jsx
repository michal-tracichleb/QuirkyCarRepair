import styles from "./ContactDetails.module.css"
import img from "../../assets//Logo_1.jpg";
export function ContactDetails(){
    return(
        <div className={styles.container}>
            <div className={styles.wrapper}>
                <h1>Serwis samochodowy oraz sklep z częściami QuirkyCarRepair</h1>

                <section>
                    <p>ul. tralala 10</p>
                    <p>11-222 Blabla</p>
                </section>
                <section>
                    <p>NIP: 1231231231</p>
                    <p>Regon: 123123123</p>
                </section>
                <section>
                    <p>Telefon: +48 987654321</p>
                    <p>E-mail: test@quirkycarrepair.pl</p>
                </section>
            </div>
            <div className={styles.img} style={{ backgroundImage: `url(${img})` }}>
            </div>
        </div>

    )
}