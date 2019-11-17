# Refactoring Notes

Zuerst wurde das Projekt besser organisiert indem ein `.sln` File und separate Projekte für Production Code und Test Code erstellt wurden.

```
dotnet new sln --name GildedRose.sln
dotnet sln GildedRose.sln add GildedRose/csharpcore.csproj
dotnet new xunit -o GildedRoseTest
dotnet sln GildedRose.sln add GildedRoseTest/GildedRoseTest.csproj
```

Danach wurde das Naming von Variablen und Typen auf C# Standards angepasst.

Als nächstes wurden Code Metriken gemessen. Einerseits wurden dafür die Rider Plugins "Cognitive Complexity" und "Cyclomatic Complexity", und andererseits Sonarqube verwendet. Außerdem außerdem ergab dotCover eine statement coverage von 51%.
Für eine Erklärung was Cognitive Complexity ist, siehe [diesen](https://www.sonarsource.com/docs/CognitiveComplexity.pdf) link.

| Metrik                | Wert | Default "noch gut" Wert |
|-----------------------|------|-------------------------|
| Cognitive Complexity  | 69   | 10                      |    
| Cyclomatic Complexity | 19   | 10                      |

Sonarqube hat zudem 6 Code Smells und einen Bug gefunden.

Bevor mit dem eigentlichen Refactoring begonnen wurde, wurden Unit Tests geschrieben, die die Statement und Branch Coverage auf 100% gehoben haben.
Die Unit Tests wurden zunächst nur anhand der geschriebenen Requirements verfasst. Als klar wurde, dass die geschriebenen Requirements nicht alle Code Pfade abdecken, wurden diese entsprechenden Tests auch nachgereicht.
Deshalb wurde ignoriert, dass _Sulfuras_ eine Quality von 80 hat, da dies nur im `Program.cs` beschrieben war, welches man laut Angabe ignorieren sollte; Es war weder im Production Code, noch im Unit Test.

Es wurde relativ schnell klar, dass wenig bzw. gar nichts des bestehenden Codes bleiben konnte; Es war viel einfacher, den bestehenden Code ganz zu löschen und die Funktionalität des Codes anhand der geschriebenen Unit Tests zu rekonstruieren (quasi TDD nur dass alle Test schon da sind).
So wurde also Schritt für Schritt (Unit Test für Unit Test) die alte Funktionalität mit neuem Code hinzugefügt.

Nachdem also die Funktionalität wieder gegeben war (Und die Test Coverage sich nicht verändert hat, was heißt, dass wirklich nur gerade so viel Code geschrieben wurde, dass die Tests grün sind), wurden die Metriken erneut gemessen:

| Metrik                | Wert | Default "noch gut" Wert |
|-----------------------|------|-------------------------|
| Cognitive Complexity  | 4    | 10                      |
| Cyclomatic Complexity | 4    | 10                      |

Auch Sonarqube zeigt nun überall optimale Werte an.

| Metrik            | Wert |
|-------------------|------|
| Bugs              | 0    |
| Vulnerabilities   | 0    |
| Security Hotspots | 0    |
| Debt              | 0    |
| Code Smells       | 0    |
| Coverage          | 100% |
| Duplications      | 0    |
| Duplicated Blocks | 0    |
