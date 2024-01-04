import styles from "./AboutDetails.module.css"
export function AboutDetails(){
    return (
        <div className={styles.wrapper}>
            <section>
                <h2>O Nas</h2>
                <p>
                    Witaj w naszym serwisie samochodowym i sklepie części! Jesteśmy pasjonatami motoryzacji, którzy od wielu lat z pełnym zaangażowaniem świadczą kompleksowe usługi związane z obsługą samochodów oraz dostarczaniem wysokiej jakości części samochodowych.
                </p>
            </section>
            <section>
                <h3>Kim Jesteśmy?</h3>
                <p>
                    Jesteśmy zespołem doświadczonych mechaników i ekspertów branżowych, którzy zdobywali swoje umiejętności w renomowanych warsztatach oraz sklepach motoryzacyjnych. Nasza pasja do samochodów napędza nas do świadczenia usług na najwyższym poziomie, z dbałością o każdy szczegół.
                </p>
            </section>
            <section>
                <h3>Usługi Serwisowe:</h3>
                <p>
                    W naszym serwisie oferujemy kompleksową obsługę samochodów osobowych i dostawczych. Od diagnostyki komputerowej po naprawy mechaniczne i elektryczne, nasz zespół zawsze stoi na wysokości zadania. Obsługujemy także klimatyzację, układy chłodzenia, przeglądy i wymiany oleju, dbając o pełną sprawność Twojego pojazdu.
                </p>
            </section>
            <section>
                <h3>Sklep Części Samochodowych:</h3>
                <p>
                    Nasz sklep części samochodowych to miejsce, gdzie znajdziesz najwyższej jakości komponenty do różnych marek i modeli pojazdów. Dbamy o to, aby nasza oferta była zawsze aktualna, obejmując silniki, układy hamulcowe, filtry i oleje, zawieszenia, elektronikę oraz akcesoria samochodowe.
                </p>
            </section>
            <section>
                <h3>Nasza Misja:</h3>
                <p>
                    Pragniemy być Twoim zaufanym partnerem w dziedzinie motoryzacji, dostarczając kompleksowe rozwiązania zarówno w obszarze serwisu samochodowego, jak i sprzedaży części. Nasza misja to zapewnienie klientom najwyższej jakości usług, profesjonalizmu i satysfakcji.
                </p>
            </section>
            <section>
                <h3>Dlaczego My?</h3>
                <ul>
                    <li>Doświadczony zespół specjalistów.</li>
                    <li>Szeroki asortyment wysokiej jakości części samochodowych.</li>
                    <li>Indywidualne podejście do każdego klienta.</li>
                    <li>Konkurencyjne ceny i atrakcyjne promocje.</li>
                    <li>Pasja do motoryzacji i zobowiązanie do doskonałości.</li>
                </ul>
            </section>
            <h1>
                Dziękujemy za zaufanie i zapraszamy do skorzystania z naszych usług. Jesteśmy gotowi sprostać wszelkim wyzwaniom związanym z Twoim samochodem!
            </h1>
        </div>
    );
}