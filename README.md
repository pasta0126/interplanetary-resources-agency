# Interplanetary Resource Agency

![GitHub](https://img.shields.io/github/license/pasta0126/interplanetary-resources-agency?style=plastic)
![GitHub last commit](https://img.shields.io/github/last-commit/pasta0126/interplanetary-resources-agency?style=plastic)
![GitHub top language](https://img.shields.io/github/languages/top/pasta0126/interplanetary-resources-agency?style=plastic)
![GitHub repo size](https://img.shields.io/github/repo-size/pasta0126/interplanetary-resources-agency?style=plastic)

![Interplanetary Resource Agency](./img/logo.png "Interplanetary Resource Agency")

[GitHub Repo](https://github.com/pasta0126/interplanetary-resources-agency)

## Introduction

This is a simple project, with a didactic purpose.

![Route 001](./img/route001.png)

## Requirements

Mandatory requirements:

- Docker
- .Net core 6

Optional requirements:

- Visual Studio 2022
- Visual Studio Code
- MS SQL Server Management Studio

## Project configuration

This project uses `User Secrets`, to manage sensitive environment configuration data, and `EF Migrations`, to admin and control changes in ddbb

### User secret

```shell
dotnet user-secrets init
```

### Migrations

```shell
dotnet tool install --global dotnet-ef
```

```shell
Add-Migration InitialMigration
```

![Route 002](./img/route002.png)

## Start up

### Docker environment

Run de docker to start the `MS SQL Server` and `RMQ`

```shell
docker-compose up -d
```

### .Net applications

1. Run de `Ira.Api`
2. Run de `Ira.Rmq.Producer`
3. Run de `Ira.Rmq.Consumer`

Can run from console or from `IDE`

To run from the console:

```shell
dotnet run <project>
```
