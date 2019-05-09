#!/bin/bash
#
dotnet restore --packages packages
dirs=('./01.Arrays' './02.String');

for dir in "$dirs"
do
    echo "########## $dir ##########"
    echo ""
    for entry in "$dir"/*
    do
    dotnet fsi "$entry"
    done
done
