using Cronofy.Api.Authorization;
using Cronofy.Api.Endpoints;
using Cronofy.Api.Extensions;
using Cronofy.Api.Swagger;
using Cronofy.Application;
using Cronofy.Domain.Entities.Applications;
using Cronofy.Infrastructure;
using Cronofy.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddEndpointsApiExplorer()
    .AddCustomSwaggerGen(builder.Configuration)
    .AddCustomApiVersioning()
    .AddCustomAuthentication()
    .AddCustomAuthorization()
    .AddApplication(builder.Configuration.GetSection(nameof(Application)).Bind)
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.Services.MigrateDatabase();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app
    .UseAuthentication()
    .UseAuthorization()
    .UseCustomExceptionHandler();

app.RegisterEndpoints();

app.Run();

public partial class Program { }