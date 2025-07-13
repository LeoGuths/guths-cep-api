using Guths.Cep.Api.Interfaces.Providers;
using Guths.Cep.Api.Interfaces.Services;
using Guths.Cep.Api.Responses;

namespace Guths.Cep.Api.Services;

public sealed class CepService : ICepService
{
    private readonly ILogger<CepService> _logger;
    private readonly List<ICepProvider> _providers;

    public CepService(
        ILogger<CepService> logger,
        IViaCepIntegration viaCepIntegration,
        IOpenCepIntegration openCepIntegration,
        IApiCepIntegration apiCepIntegration,
        IBrasilApiIntegration brasilApiIntegration,
        IBrasilAbertoIntegration brasilAbertoIntegration)
    {
        _logger = logger;
        _providers =
        [
            viaCepIntegration,
            openCepIntegration,
            apiCepIntegration,
            // brasilAbertoIntegration, // Desativado temporariamente devido a problemas de autenticação
            brasilApiIntegration
        ];
    }

    public async Task<AddressResponse?> GetAddressAsync(string cep)
    {
        foreach (var provider in _providers)
        {
            try
            {
                _logger.LogInformation("Tentando consultar CEP {Cep} no provedor {Provider}", cep, provider.ProviderName);
                
                var result = await provider.GetAddressAsync(cep);
                
                if (result != null)
                {
                    _logger.LogInformation("CEP {Cep} encontrado no provedor {Provider}", cep, provider.ProviderName);
                    result.Provider = provider.ProviderName;
                    return result;
                }
                
                _logger.LogWarning("CEP {Cep} não encontrado no provedor {Provider}", cep, provider.ProviderName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar CEP {Cep} no provedor {Provider}", cep, provider.ProviderName);
            }
        }

        _logger.LogWarning("CEP {Cep} não encontrado em nenhum provedor", cep);
        return null;
    }
}