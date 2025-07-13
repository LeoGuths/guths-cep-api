using System.Diagnostics.CodeAnalysis;
using Guths.Cep.Api.Interfaces.Providers;
using Guths.Cep.Api.Interfaces.Services;
using Guths.Cep.Api.Services;

namespace Guths.Cep.Api.Configuration.IoC;

[ExcludeFromCodeCoverage]
public static class ServicesConfig
{
    public static void AddServicesDependencies(this IServiceCollection services)
    {
        services.AddScoped<IViaCepIntegration, ViaCepIntegration>();
        services.AddScoped<IOpenCepIntegration, OpenCepIntegration>();
        services.AddScoped<IApiCepIntegration, ApiCepIntegration>();
        services.AddScoped<IBrasilApiIntegration, BrasilApiIntegration>();
        services.AddScoped<IBrasilAbertoIntegration, BrasilAbertoIntegration>();
        
        services.AddScoped<ICepService, CepService>();
    }
}