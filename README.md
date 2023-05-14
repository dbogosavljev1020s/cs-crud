# ADO.NET
## Pripremanje projekta
1. `TSQL DB Create Script.sql` pokrenuti u SSMS-u (Kreiranje baze podataka i tabela)
2. Povezati Visual Studio projekat sa bazom podataka
3. Pokrenuti `SqlScript.sql` (kopiranje tabele i kreiranje potrebnih procedura)
4. Pokrenuti program i učitati podatke pritskom na `**_Refresh grid_**`

## Funkcionalnosti
**INSERT** - Unos novog klijenta. Pre unosa u bazu, vrši se ispravnos podataka.<br><br>
**UPDATE** - Izmena podataka izabranog klijenta iz tabele. Pre promene podataka u bazi, vrši se validacija podataka.<br><br>
**DELETE** - Brisanje izabranog klijenta iz baze.<br><br>
**_Refresh grid_** - Osvežavanje prikaza tabele. Nakon svakog uspesnog izvrsavanja INSERT, UPDATE ili DELETE, mora ručno da se osveži tabela.<br><br>
**EXIT** - Izlaz is programa
