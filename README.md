# Cronofy API #

### Entity Framework ###

#### Migrations ####

To add a new migration, run the following command from the root of the repository:

```
dotnet ef migrations add <<MIGRATION-NAME>> 
    --startup-project .\src\Cronofy.Api\ 
    --project .\src\Cronofy.Infrastructure\ 
    --output-dir .\Persistence\Migrations 
    --context CronofyWriteDbContext
```

To remove the most recent migration, run the following command from the root of the repository:

```
dotnet ef migrations remove 
    --startup-project .\src\Cronofy.Api\ 
    --project .\src\Cronofy.Infrastructure\  
    --context CronofyWriteDbContext
```