using Guths.Cep.Api.Interfaces.Providers;
using Guths.Cep.Api.Interfaces.Refit;
using Guths.Cep.Api.Responses;

namespace Guths.Cep.Api.Services;

public sealed class BrasilApiIntegration : IBrasilApiIntegration
{
    private readonly IBrasilApiIntegrationRefit _brasilApiIntegrationRefit;
    
    public string ProviderName => "Brasil API";

    public BrasilApiIntegration(IBrasilApiIntegrationRefit brasilApiIntegrationRefit)
    {
        _brasilApiIntegrationRefit = brasilApiIntegrationRefit;
    }

    public async Task<AddressResponse?> GetAddressAsync(string cep)
    {
        var responseData = await _brasilApiIntegrationRefit.GetAddressFromBrasilApi(cep);

        if (responseData is { IsSuccessStatusCode: true, Content: not null })
        {
            return new AddressResponse(
                ZipCode: responseData.Content.Cep,
                Street: responseData.Content.Street,
                Neighborhood: responseData.Content.Neighborhood,
                City: responseData.Content.City,
                Uf: responseData.Content.State
            );
        }

        return null;
    }
}