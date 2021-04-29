# Hahn applicatonProcess application

## Frontend built With

- [Aurelia](http://aurelia.io/docs/tutorials/creating-a-todo-app#setup) - The web framework used
- [Bootstrap](https://getbootstrap.com/docs/4.6/getting-started/download) - UI library

## Backend built With

- [NetCore](https://docs.microsoft.com/en-us/dotnet/) - The webapi framework used

### Server

### Installing App

Get git source code :

```sh
$ git clone https://github.com/ronnysuero/Hahn.ApplicatonProcess.Application.git
```

Restore DotNET and Npm packages :

```sh
$ cd Hahn.ApplicatonProcess.Application
$ dotnet build Ticket.Web/Ticket.Web.csproj /property:GenerateFullPaths=true /consoleloggerparameters:NoSummary
```

Create docker image :

```sh
$ docker build -t ticketweb -f Ticket.Web/Dockerfile .
$ docker run --rm -d  -p 5000:5000/tcp ticketweb
```

Go to the browser: `http://localhost:5000/` and that's it.

## Author

Ronny Zapata – ronnysuero@gmail.com

## License

This software is licensed under the [MIT](https://github.com/nhn/tui.editor/blob/master/LICENSE) ©