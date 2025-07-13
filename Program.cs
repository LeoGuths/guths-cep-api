using System.Reflection;
using Guths.Cep.Api.Configuration.IoC;
using Guths.Cep.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var isProduction = builder.Environment.IsProduction();

if (!isProduction)
    builder.Services.AddOpenApi();

builder.Services.AddServicesDependencies();
builder.Services.AddExternalServicesDependencies();

var app = builder.Build();

if (!isProduction)
    app.AddScalarConfiguration(Assembly.GetExecutingAssembly().GetName().Name!);

app.MapCepEndpoints();

app.Run();