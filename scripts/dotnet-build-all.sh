#!/bin/bash

for csproj in $(find src -name "*.csproj")
do
    echo "Building $csproj..."
    dotnet build $csproj -c Debug -f net8.0
done
