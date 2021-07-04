## ShopBridge API
1. DotNet core 3.1
2. Entity Framework
3. Swagger
4. MS SQL

#### How to run
Run as ShopBridge.API as Startup project

#### Swagger UI
Swagger is configured in the below url for documentation
https://localhost:44391/swagger/index.html

#### Updating Database
```
Update-Database -Verbose -Context AppDbContext -Project DataAccess -StartupProject ShopBridge.API

```

#### Key Values 
1. Used clean code archtecture, Controller => Services => Repository pattern
2. Explicit DTO and Entity objects. DTOs can be used for UI data massaging, entity representing data store model	


#### Effort

| Sl. No | Task                                                              | Effort |
|--------|-------------------------------------------------------------------|--------|
| 1      | Setting clean code arch.                                          | 1 hour |
| 2      | Data model design, migrations, Identity server                    | 30 min |
| 3      | Developing CRUD operations for inventory, category, auth services | 1 hour |
| 4      | Bug fixes, Unit testing, Documentation preparation, Integration   | 1 hour |

#### Known Issues

1. Auth service is not fully configured and secured enough. Good for a POC
2. Swagger Authorize value needs to be ```Bearer <JWT>```
3. Test coverage is on high level, needs more