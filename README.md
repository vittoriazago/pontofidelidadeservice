# Serviço de Ponto Fidelidade [![Build Status](https://travis-ci.org/vittoriazago/pontofidelidadeservice.svg?branch=master)]


## Technologies
* .NET Core 2.2
* ASP.NET Core 2.2
* Identity
* Entity Framework Core 2.2
* Entity Framework Core Migrations 2.2
* Seed
* SqlServer 2017
* Restful WebApi
* NUnit

## Execução

Para executar a Api basta executar:
* dotnet run
Acesse para ver a documentação:
* localhost:44368/swagger

Cadastre um usuário em:
* POST /api/Usuario
Autenticação:
* /api/Usuario/login
Token gerado com o padrão Bearer, exemplo:
* Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxI....


## Funcionalidades
* Cliente pode consultar seu saldo por CPF



