import styles from "./HomePage.module.css"
import img from "../../assets/VistaCarMechanic.jpeg";
import {CenteredContent} from "../CenteredContent/CenteredContent.jsx";

export function HomePage(){
    return(
        <div>
            <div className={styles.header} style={{ backgroundImage: `url(${img})` }}>
                <CenteredContent>
                    <div className={styles.headerWrapper}>
                        <h2>Witamy w Serwisie Samochodowym i Sklepie Części QuirkyCarRepair</h2>
                        <p>W naszej ofercie znajdą Państwo profesjonalną obsługę w zakresię naprawy pojazdów oraz szeroki wybór wysokiej jakości części samochodowych.</p>
                    </div>
                </CenteredContent>
            </div>
            <div className={styles.contentWrapper}>
                <section>
                    <h1>Oferta Serwisu Samochodowego</h1>
                    <p>
                        Kompleksowa obsługa samochodów osobowych i dostawczych.
                        Diagnostyka komputerowa, naprawy mechaniczne i elektryczne.
                        Obsługa klimatyzacji i układów chłodzenia.
                        Przeglądy i wymiana oleju. Szybka obsługa napraw gwarancyjnych.
                    </p>
                </section>
                <section>
                    <h1>Oferta Sklepu Części Samochodowych</h1>
                    <p>
                        Najnowsze i najwyższej jakości części do różnych marek i modeli samochodów.
                        Kategorie produktów: Silniki, Układ hamulcowy, Filtry i oleje, Zawieszenie, Elektronika, Akcesoria samochodowe.
                    </p>
                </section>
                <section>
                    <h1>Zaufanie i Doświadczenie</h1>
                    <p>
                        Wieloletnie doświadczenie w branży.
                        Pozytywne opinie klientów zarówno dla serwisu, jak i sklepu z częściami.
                    </p>
                </section>
                <section>
                    <h1>Kontakt</h1>
                    <p>
                        Skontaktuj się z nami, aby umówić się na wizytę w serwisie lub uzyskać informacje o dostępności części.
                        Numer telefonu, formularz kontaktowy, adres e-mail.
                        Możesz także sprawdzić dostępność części tutaj oraz umówić wizytę w serwisie online tutaj.
                    </p>
                </section>
                <section>
                    <h1>Promocje</h1>
                    <p>
                        Aktualne promocje i rabaty dla klientów.
                        Specjalne oferty dla stałych klientów serwisu i sklepu.
                    </p>
                </section>
            </div>
        </div>
    )
}