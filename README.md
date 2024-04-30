# Documentando os comandos do curso TDD no dotnet

### comando para listar os sdks dotnet
dotnet --list-sdks 

### comando para criar a solução do projeto
dotnet new sln -n SolucaoExemplo 

### criando um json global para setar qual dotnet será usado
dotnet new globaljson --sdk-version 7.0.101

### criando o projeto na src
dotnet new classlib -n Data

### criando o projeto na test
dotnet new xunit -n Data.Tests

### Adicionar todos os projetos dentro da solução
dotnet sln add */*/*.csproj

outro exemplo:
dotnet sln add .\test\Data.Tests\Data.Tests.csproj
dotnet sln add .\src\Data\Data.csproj 

### saber qual projeto vai testar
dotnet add .\test\Data.Tests\Data.Tests.csproj reference .\src\Data\Data.csproj

### instenções 
c###
.net core Test Explore

### configuração do Settings.json

{
    "dotnet-test-explorer.testProjectPath": "**/*/*.Tests.csproj",
    "dotnet-test-explorer.enableTelemetry": false
}
    

# Criando projeto - seção 4

## Criando base de dados

Create Database Agenda
go

create table Contato
(
    ID uniqueidentifier primary key,
    Nome varchar(100)
)

