# Refactoring notes

first, organize the project by creating a solution file and separate projects for production code and tests

```
dotnet new sln --name GildedRose.sln
dotnet sln GildedRose.sln add GildedRose/csharpcore.csproj
dotnet new xunit -o GildedRoseTest
dotnet sln GildedRose.sln add GildedRoseTest/GildedRoseTest.csproj
```
dann standards anpassen wie varabilen namem und field namen

sonarqube und extensions laufen lassen laufen lassen

cognitive complexity: 69
cyclomatic complexity: 19
statement coverage: 51%

sonarqube found one bug
6 code smells

dotnet sonarscanner begin /k:"gildedrosecsharpcore" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="919e13f0d8f7df50e7d48cf89c721f22d7774ab3"


