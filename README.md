# Projekt HandIn Manager

## Anlegen der Solution

```
md HandInManagerApp
cd HandInManagerApp
md HandInManagerApp.Application
md HandInManagerApp.Test
md HandInManagerApp.Webapp

cd HandInManagerApp.Application
dotnet new classlib
dotnet add package Microsoft.EntityFrameworkCore --version 6.*
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.*
dotnet add package Microsoft.EntityFrameworkCore.Proxies --version 6.*

cd ..\HandInManagerApp.Test
dotnet new xunit
dotnet add reference ..\HandInManagerApp.Application

cd ..\HandInManagerApp.Webapp
dotnet new webapp
dotnet add reference ..\HandInManagerApp.Application

cd ..
dotnet new sln
dotnet sln add HandInManagerApp.Webapp
dotnet sln add HandInManagerApp.Application
dotnet sln add HandInManagerApp.Test
start HandInManagerApp.sln
```