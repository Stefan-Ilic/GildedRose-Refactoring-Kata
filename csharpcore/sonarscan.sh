#!/bin/sh

dotnet sonarscanner begin /k:"gildedrosecsharpcore" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="919e13f0d8f7df50e7d48cf89c721f22d7774ab3"
dotnet build
dotnet sonarscanner end /d:sonar.login="919e13f0d8f7df50e7d48cf89c721f22d7774ab3"