using Guths.Cep.Api.Interfaces.Providers;
using Guths.Cep.Api.Interfaces.Refit;
using Guths.Cep.Api.Responses;

namespace Guths.Cep.Api.Services;

public class ViaCepIntegration : IViaCepIntegration
{
    private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;
    
    public string ProviderName => "ViaCep";
    
    public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit)
    {
        _viaCepIntegrationRefit = viaCepIntegrationRefit;
    }

    public async Task<AddressResponse?> GetAddressAsync(string cep)
    {
        var responseData = await _viaCepIntegrationRefit.GetAddressFromViaCep(cep);

        if (responseData is { IsSuccessStatusCode: true, Content: not null })
        {
            return new AddressResponse(
                ZipCode: responseData.Content.Cep,
                Street: responseData.Content.Logradouro,
                Neighborhood: responseData.Content.Bairro,
                City: responseData.Content.Localidade,
                State: responseData.Content.Estado,
                Uf: responseData.Content.Uf
            );
        }

        return null;
    }
}