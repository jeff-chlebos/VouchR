#!/bin/bash

for csproj in $(find src -name "*.csproj")
do
    echo "Restoring $csproj..."
    dotnet restore $csproj --no-cache
done
