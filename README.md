# Kanban board
## ASP.NET backend and React.js frontend



A konkrét feladat egy Kanban board létrehozása amin a teendőket prioritásuk és státuszuk szerint oszlopokba rendezve jelenít meg.

A teendők a user által létrehozhatók, szerkezthetők, törölhetők, státuszuk módosítható.

## Főbb funkcók

- Teendő létrehozása megjelenő moduláris ablakban
- Teendő szekeztése megjelnő moduláris ablakban
- Teendő törlése törlés gombra kattintva
- Teendő KÉSZ státuszba állítása gombra kattintva
- A felületen történő módosításaok API hívással backenden mentődik le


## Használt technológiák

Az alkalmazás az alábbi technológiákat használja:

- [ReactJs] - JavaScript alapú frontend framework
- [ASP.NET] - ASP.NET framework felel a backend REST funkcókért
- [MSSQL] - adatbázis 
- [Bootstrap] - design


## Alkalmazás felépítése

Az alkalmazás klasszikusan felbontható frontend-re és backend-re.

### Backend

A backend kód háromrétegű architektúra szerint lett fejlesztve. Ezek a rétegek a :
- Data Access Layer
- Business Logic Layer
- Presentation Layer

#### Data Access Layer

ide kép
Három fő részből áll a Dtos, Models és Repositories mappákból, ezek feladatukat tekintve lettek így elszeparálva.

A Dtos mappa tárolja a Data Transfer Objecteket, ilyen típusú információkat szolgáltat a backend a frontend számára.

A Models mappában az alkalmazás entitánsai vannak, ők írják le az adatbázis modelt és a táblák közötti kapcsolatot.

A Repositories mappában Repository Pattern alapján helyezkednek az adatelérési réteg interfészei, ezeket éri el a Bll réteg adatelérés céljából.

### Business Logic Layer
ide kép




