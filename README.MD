## ShopBridge API
1. DotNet core 3.1
2. Entity Framework
3. Swagger
4. MS SQL

#### How to run
Run as ShopBridge.API as Startup project

#### Swagger UI
Swagger is configured in the below URL for documentation
https://localhost:44391/swagger/index.html

#### Updating Database
```
Update-Database -Verbose -Context AppDbContext -Project DataAccess -StartupProject ShopBridge.API

```

#### Key Values 
1. Used clean code architecture, Controller => Services => Repository pattern with EF ORM
2. Explicit DTO and Entity objects. DTOs can be used for UI data massaging, the entity representing data store model	
3. Global exception handler to catch exceptions
4. Exceptions are logged with serilog, logged to ./logs folder
5. Identity Server added for handling Authentication, 
6. Application Authorization with JWT tokens
7. Controller level Role base authorization for ```Admins```
8. Self-documentation with Swagger Swashbuckle


#### Effort

| Sl. No | Task                                                              | Effort  |
|--------|-------------------------------------------------------------------|---------|
| 1      | Setting clean code arch.                                          | ~1 hour |
| 2      | Data model design, migrations, Identity server                    | 1 hour  |
| 3      | Swagger set up and config										 | 30 min  |
| 4      | SeriLog setup up and congif								         | 30 min  |
| 5      | Setting up global error handler									 | 30 min  |
| 6      | Developing CRUD operations for inventory, category, auth services | ~1 hour |
| 7      | Bug fixes, Unit test setup, high level unit test cases		     | 1 hour  |
| 8      | Integration process, Documentation preparation					 | 1 hour  |

#### Known Issues

1. Auth service is not fully configured and secured enough. Good for a POC
2. Swagger Authorize value needs to be ```Bearer <JWT>```
3. Test coverage is on high level, needs more