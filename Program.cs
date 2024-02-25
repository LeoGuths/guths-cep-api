using Guths.CEP.API.Endpoints;
using Guths.CEP.API.Refit;
using Guths.CEP.API.Services;
using Guths.CEP.API.Services.Interfaces;
using Refit;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IViaCepIntegracao, ViaCepIntegracao>();
builder.Services.AddRefitClient<IViaCepIntegracaoRefit>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("https://viacep.com.br");
});

var app = builder.Build();

app.MapViaCepEndpoints();

app.Run();