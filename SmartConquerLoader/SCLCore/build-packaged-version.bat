@echo off
@title Build Packaged Exe
dotnet publish -r win-x64 -c Release
pause