# Short URL API

## What is this?

This is the API of a system to compress URLs and redirect user when the compressed URL is accessed.

Deployed API: <https://shturl.azurewebsites.net/api/info>  
Deployed Front End <https://short-url.azurewebsites.net>   
Front End Repository: <https://github.com/will-steffen/ShortURL-FRONT>


## Technologies
It uses .NET Core 2.1, created as `webapi`, and ready to be hosted on premise (by Kestrel) or deployed on Azure as Web App (Azure App Services). Here some things is uses:
- .NET Core
- Entity Framework Core
- xUnit

## Running
First you need to be sure that you have .NET Core installed on you environment. You can grab it from <https://dotnet.microsoft.com/download/dotnet-core/2.1>. I used the version SDK 2.1.402.

This is prepared to Run with MySQL Database, but it can run with Memory DB.

##### Running with Memory DB
- Open the file `/ShortUrl/ShortURL.Api/appsettings.json`. 
- Locate the key `UseMemoryDB` and set it to `true`.

##### Running with MySQL
- Install a MySQL instance (or use it rometely). I Used the version 5.7;
- Create a user and make sure your computer can access the instance;
- Create a new database: `CREATE DATABASE <your_db_name> CHARACTER SET utf8 COLLATE utf8_general_ci;`
- Open the file `/ShortUrl/ShortURL.Api/appsettings.json`. 
- Locate the key `UseMemoryDB` and set it to `false`;
- Locate the key `DefaultConnection`and set it following your connection string: `"server=<your_host>;uid=<your_username>;pwd=<user_password>;database=<your_db_name>"`;
- The database schema will be updated by `Migrations`, when server becomes online;

##### Finishing Configuration
Maybe you have not read the front-end document yet, but you need to configure the front not-found URL here, in the key `NotFoundRedirectURL` of appsettings.json. If you will run it on localhost, with standard Angular port, leave it as cloned.

##### Running Tests (Optional)
- Navigate to `/ShortUrl/ShortURL.Test`;
- Execute `dotnet test`;

##### Finaly Running
- Navigate to `/ShortUrl/ShortURL.Api`, and execute `dotnet run`;
- Now you can browse <http://localhost:5000/api/info>;
- You will see just a simple string saying server is online.


## Architecture
This API follows the classic WebAPI architecture, with code separated in layers.

###### ShortURL.Api
The layer responsible for receive the requests and delegate which class should execute in that context. Routes are defined in Controllers Classes. That is the main project, so the boot of server is here, in the `Startup` folder.

###### ShortURL.Business
The layer responsible for implemets the business logic. Is referenced direcly in Controllers, and call DataAccess Classes.

###### ShortURL.DataAccess
The layer responsible to access the database and execute necessary queries.

###### ShortURL.DomainModel
The model layer. Has all entities of domain, like DB models, exceptions, enums, interfaces (of models) and migrations;

###### ShortURL.Test
The project where unit tests are write.


## Routes Map
- `/{code} : GET` -> Search the saved code and redirect to the original URL. If the code doesn't exist, redirect to the front not-found route;
- `/api/info : GET` -> Displays the server online message;
- `/api/user : GET` -> Creates a new register for a client. It is used to remeber the user its shortened links when returning to the system. This information will be stored on localStorage by the front-end;
- `/api/user/valid/{userId} : GET` -> Return if the informed userId still valid on the system, or if front-end needs to request a new one;
- `/api/url : POST` -> Receive the original URL and creates the shortened URL;
- `/api/url/count/{code} : GET` -> Return how many clicks a shortened URl was used;
- `/api/url/last/{userId} : GET` -> Return last 2 shortened URLs created by this userId;
- `/api/url/stats/{code} : GET` -> Return the statistics of this shortened URL. It only returns the list of cliks (date and ip of client) up to 10 most recent clicks;
- `/api/url/metadata-title/{code} : GET` -> Serach in the original URL the title of targeted page;

## Command Utils
- SQL to create a database: `On SQL Editor` 
  - CREATE DATABASE short_url CHARACTER SET utf8 COLLATE utf8_general_ci;
- Create a new automatic Migration of models: `On /ShortURL.DomainModel` 
  - dotnet ef migrations add <migration_mame> --context ApplicationContext
- Build server to deploy on Azure Web App: `On /ShortURL.Api`
  - dotnet publish --configuration=Release --runtime debian.8-x64
- Run Unit Tests: `On /ShortURL.Test`
  - dotnet test
