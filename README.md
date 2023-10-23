# CarService - QuirkyCarRepair
Quirky Car Repair to aplikacja mająca na celu ułatwienie zarządzania serwisem samochodowym z magazynem części, obsługę sprzedaży i usług wraz z systemem rozliczania.

# Główne Funkcje Systemu:
1. Zarządzanie Magazynem:
    - Dodawanie nowych części do magazynu wraz z ich opisami, cenami, kategorią, dostawcą i ilościami.
    - Aktualizacja informacji o częściach, w tym cen i ilości w magazynie.
    - Przeglądanie stanu magazynowego dla różnych części.

2. Obsługa Sprzedaży:
    - Składanie zamówień na części przez klientów.
    - Tworzenie faktur dla klientów w przypadku sprzedaży części.
    - Aktualizacja stanu magazynowego po każdej sprzedaży.

3. Zarządzanie Usługami Naprawczymi:
    - Rejestrowanie zgłoszeń serwisowych od klientów.
    - Przypisywanie pracowników do napraw i ustalanie terminów napraw.
    - Rejestracja czasu pracy, użytych części oraz opisu przeprowadzonych napraw.
    - Generowanie raportów o kosztach napraw i dostępności części.

4. Monitorowanie Stanu Samochodów:
    - Dodawanie samochodów do systemu wraz z ich markami, modelami i numerami rejestracyjnymi.
    - Aktualizacja statusów samochodów (np. w trakcie naprawy, gotowy do odbioru).
    - Przeglądanie historii napraw dla każdego samochodu.

5. Rozliczanie i Fakturowanie:
    - Obliczanie kosztów napraw i usług serwisowych.
    - Tworzenie faktur dla klientów na podstawie przeprowadzonych napraw.
    - Umożliwienie klientom płatności online za usługi i części.

6. Przeglądanie Raportów i Statystyk:
    - Generowanie raportów dotyczących sprzedaży, kosztów napraw, dostępności części, itp.
    - Przeglądanie statystyk dotyczących wydajności pracowników serwisu.

## Technologie:
* API: C#, EF Core, ASP.NET Core
* Baza Danych: MSSQL
* Frontend: React
* System Kontroli Wersji: GitHub
* Kontener: Docker
