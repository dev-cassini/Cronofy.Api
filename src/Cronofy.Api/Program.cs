using Cronofy.Api.Endpoints;
using Cronofy.Api.Extensions;
using Cronofy.Application;
using Cronofy.Domain;
using Cronofy.Domain.Entities;
using Cronofy.Infrastructure;
using Cronofy.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddCustomApiVersioning()
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

app.RegisterEndpoints();
app.UseCustomExceptionHandler();

app.Run();