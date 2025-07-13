using Guths.Cep.Api.Interfaces.Providers;
using Guths.Cep.Api.Interfaces.Refit;
using Guths.Cep.Api.Responses;

namespace Guths.Cep.Api.Services;

public sealed class BrasilAbertoIntegration : IBrasilAbertoIntegration
{
    private readonly IBrasilAbertoIntegrationRefit _brasilAbertoIntegrationRefit;
    
    public string ProviderName => "Brasil Aberto";

    public BrasilAbertoIntegration(IBrasilAbertoIntegrationRefit brasilAbertoIntegrationRefit)
    {
        _brasilAbertoIntegrationRefit = brasilAbertoIntegrationRefit;
    }

    public async Task<AddressResponse?> GetAddressAsync(string cep)
    {
        var responseData = await _brasilAbertoIntegrationRefit.GetAddressFromBrasilAberto(cep);

        if (responseData is { IsSuccessStatusCode: true, Content: not null })
        {
            return new AddressResponse(
                ZipCode: responseData.Content.Result.Zipcode,
                Street: responseData.Content.Result.Street,
                Neighborhood: responseData.Content.Result.District,
                City: responseData.Content.Result.City,
                Uf: responseData.Content.Result.StateShortname,
                State: responseData.Content.Result.State
            );
        }

        return null;
    }
}
