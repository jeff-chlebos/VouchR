#!/bin/bash

display_help() {
  echo "Usage: $0 [options]"
  echo "Options:"
  echo "  -v    Package version"
  echo "  -p    Repository Personal Access Token (PAT)"
  echo "  -r    Registry name"
  echo "  -h    Show this help message"
}

while getopts v:p:r:h: option; do
  case $option in
    v) version=${OPTARG};;
    p) pat=${OPTARG};;
    r) registry=${OPTARG};;
    h) display_help; exit 0;;
    *) display_help; exit 1;;
  esac
done

if [ -z "$version" ] || [ -z "$pat" ] || [ -z "$registry" ]; then
  echo "Missing required options."; display_help; exit 1;
fi

dotnet pack -c Release -p:PackageVersion=$version --output packages
dotnet nuget push packages/*$version.nupkg -k $pat -s https://nuget.pkg.github.com/$registry/index.json --skip-duplicate
