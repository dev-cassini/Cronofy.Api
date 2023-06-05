using Cronofy.Infrastructure;
using Cronofy.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.Services.MigrateDatabase();

app.MapGet("/", () => "Hello World!");

app.Run();