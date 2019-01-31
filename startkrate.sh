#!/usr/bin/env bash

SERVER_PATH="./KRATE.Proof.of.Concept/src/Krate.KrateD/"
TUI_PATH="./TUI/"

if [[ -d $SERVER_PATH ]]; then
    SERVER_PATH="$SERVER_PATH/"
else
    echo "path to server needs to be a directory"
    exit 1
fi

if [[ -d $TUI_PATH ]]; then
    TUI_PATH="$TUI_PATH/"
else
    echo "path to TUI needs to be a directory"
    exit 1
fi

# Running Server
echo "RUNNING SERVER AT: $SERVER_PATH"
cd $SERVER_PATH && dotnet run >>/dev/null 2>>/dev/null &

# Running TUI
echo "RUNNING TUI AT: $TUI_PATH"
cd $TUI_PATH && dotnet run

