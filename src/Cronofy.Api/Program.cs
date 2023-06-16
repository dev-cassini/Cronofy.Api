using Cronofy.Api;
using Cronofy.Application;
using Cronofy.Domain;
using Cronofy.Infrastructure;
using Cronofy.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDomain()
    .AddApplication(builder.Configuration.GetSection(nameof(Application)).Bind)
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.Services.MigrateDatabase();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");

app.Run();