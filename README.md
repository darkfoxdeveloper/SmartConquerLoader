# SmartConquerLoader
Smart Loader for Conquer Online Clients

## What is SmartConquerLoader?
A loader to connect to a private server and can easily configure the connection

## Tecnologies used
The latest microsoft framework called Net Core is used in its latest version 3.1

## Minimal Requeriments
Windows 7 SP1
Netcore 3.1 (only for develop)

## Features
- Connection to a previously configured server
- Allow Multiple connections to multiple servers
- Manager for configuration called 'SCLManager'
- Posibility of change GameCryptographyKey and protect the game for only enter if have the valid key (Partially implemented)

### Important information about source
###### Have multiple projects with the sources in this repository.
- SCLCore is a library used by others projects, contains some important things
- SCLHook is a library used by loader for inject in conquer.exe the needed things for allow connection to configured server ip and ports
- SCLManager is a manager (GUI) for the configuration file 'config.json'
- SCLSync is a library (created in .NetFramework 4.5 for more compatibility with other projects) for syncronize data sended by loader and the client
- SmartConquerLoader is the loader, that loader inject the dll of 'SCLHook' project build

### More info (Sorry, but is in Spanish)
https://www.forum.darkfoxdeveloper.com/d/237-smartconquerloader-proyecto-de-loader-open-source-para-conquer
