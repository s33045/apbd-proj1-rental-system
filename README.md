## Wymagane
- .NET 10 SDK

## Uruchomienie
```bash
git clone https://github.com/s33045/apbd-proj1-rental-system.git
cd apbd-proj1-rental-system/apbd-proj1-rental-system/apbd-proj1-rental-system
dotnet build
dotnet run
```

## Decyzje projektowe
Projekt w swojej strukturze wykorzystuje modele domenowe opisujące konkretne podmioty, klasy serwisowe zawierające logikę biznesową, a także klasę zarządzającą, która jest głównym punktem interakcji z systemem. Ta struktura pozwala na czysty podział obowiązków między warstwami - modele domenowe opisują konkretne obiekty z treści zadania, klasy serwisowe używają tych modeli w logice biznesowej, a główna klasa aplikacji wykorzystuje udostępnioną przez serwisy funkcjonalność i zapewnia wygodny interfejs API do interakcji z zewnątrz.
