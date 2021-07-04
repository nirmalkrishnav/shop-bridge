## ShopBridge API
DotNet core 3.1
Entity Framework
Swagger
MS SQL

#### How to run
1. ``Dotnet run --project ShopBridge.API`` in cmd

#### Swagger UI
Swagger is configured in the below url for documentation
https://localhost:44391/swagger/index.html
	
#### 

```

Add-Migration <name> -Verbose -Context AppDbContext -Project DataAccess -StartupProject ShopBridge.API

Update-Database -Verbose -Context AppDbContext -Project DataAccess -StartupProject ShopBridge.API

```