# Cronofy API #

### Entity Framework ###

#### Migrations ####

To add a new migration, run the following command from the root of the repository:

```
dotnet ef migrations add <<MIGRATION-NAME>> --startup-project .\src\Cronofy.Api\ --project .\src\Cronofy.Infrastructure\ --output-dir .\Persistence\Migrations --context CronofyWriteDbContext
```

To remove the most recent migration, run the following command from the root of the repository:

```
dotnet ef migrations remove --startup-project .\src\Cronofy.Api\ --project .\src\Cronofy.Infrastructure\ --context CronofyWriteDbContext
```

### Local Development ###

#### User Secrets ####
https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows

Add Cronofy application client id and secret to secret storage:

```
dotnet user-secrets set "CronofyApplication:ClientId" "CRONOFY_APPLICATION_CLIENT_ID"
dotnet user-secrets set "CronofyApplication:ClientSecret" "CRONOFY_APPLICATION_CLIENT_SECRET"
```

Add Postgres connection string to secret storage by running the following command from the root of the Cronofy.Api project replacing the value with your Postgres connection string.

Connection string format: Host=localhost;Username=USERNAME_HERE;Password=PASSWORD_HERE;Database=Cronofy.Api;Include Error Detail=true

```
dotnet user-secrets set "ConnectionStrings:Postgres" "POSTGRES_CONNECTION_STRING"
```

Add RabbitMQ connection string to secret storage by running the following command from the root of the Cronofy.Api project replacing the value with your Postgres connection string.

Connection string format: rabbitmq://USERNAME_HERE:PASSWORD_HERE@localhost

```
dotnet user-secrets set "ConnectionStrings:RabbitMq" "RABBITMQ_CONNECTION_STRING"
```

#### Docker ####

Run the following command from the root of the repository to spin up docker containers required to run the app:

```
docker-compose up -d --build
```