using System.Diagnostics.CodeAnalysis;
using Guths.Cep.Api.Interfaces.Refit;
using Refit;

namespace Guths.Cep.Api.Configuration.IoC;

[ExcludeFromCodeCoverage]
public static class ExternalServicesConfig
{
    public static void AddExternalServicesDependencies(this IServiceCollection services)
    {
        services.AddRefitClient<IViaCepIntegrationRefit>().ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri("https://viacep.com.br");
        });

        services.AddRefitClient<IOpenCepIntegrationRefit>().ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri("https://opencep.com");
        });

        services.AddRefitClient<IApiCepIntegrationRefit>().ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri("https://cdn.apicep.com");
        });

        services.AddRefitClient<IBrasilApiIntegrationRefit>().ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri("https://brasilapi.com.br");
        });

        services.AddRefitClient<IBrasilAbertoIntegrationRefit>().ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri("https://api.brasilaberto.com");
        });
    }
}