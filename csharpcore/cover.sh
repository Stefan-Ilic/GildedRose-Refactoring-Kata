#!/bin/sh

coverlet ./GildedRoseTest/bin/Debug/netcoreapp3.0/GildedRoseTest.dll  --target "dotnet" --targetargs "test GildedRoseTest/GildedRoseTest.csproj  --no-build" --format opencover --exclude '[*]GildedRose.Program'
reportgenerator -reports:coverage.opencover.xml -targetdir:reports