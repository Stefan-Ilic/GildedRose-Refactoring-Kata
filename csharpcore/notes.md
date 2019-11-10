# Refactoring notes

first, organize the project by creating a solution file and separate projects for production code and tests

```
dotnet new sln --name GildedRose.sln
dotnet sln GildedRose.sln add GildedRose/csharpcore.csproj
dotnet new xunit -o GildedRoseTest
dotnet sln GildedRose.sln add GildedRoseTest/GildedRoseTest.csproj
```
dann standards anpassen wie varabilen namem und field namen
