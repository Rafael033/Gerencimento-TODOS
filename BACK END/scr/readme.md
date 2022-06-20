#Necessario Para Rodar o Projeto:

1° SQLSERVER Instância local que é instalada automaticamente com o Microsoft SQL Server Management Studio 
 server name: "(localdb)\mssqllocaldb"

2°Abra a solution(TODOS.sln) dentro da Pasta TODOS.API utilizando Visual Studio 2019 ou uma versão superior. 
 Siga os passos:
-Aba Tools>NuGet Package Manager>Package Manager Console

-digite no console: update-database

Opcicional: executar pelo vscode abrir a pasta TODOS.API abrir o terminal
digitar: dotnet ef database update
e: dotnet run
abrir o navegador e digitar a url: 

3° Execute o debug(F5), já vai abrir na pagina do swagger para testar os verbos da API.


Tecnologias e frameworks utilizados:
-ASPNETCORE 5
-EntityFramework Core 5
-EntityFramework Designer 5
-EntityFramework SqlServer 5
-Padrão MVC


