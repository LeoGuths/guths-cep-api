using Guths.Cep.Api.Endpoints;
using Guths.Cep.Api.Refit;
using Guths.Cep.Api.Services;
using Guths.Cep.Api.Services.Interfaces;
using Refit;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IViaCepIntegration, ViaCepIntegration>();
builder.Services.AddRefitClient<IViaCepIntegrationRefit>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("https://viacep.com.br");
});

var app = builder.Build();

app.MapViaCepEndpoints();

app.Run();