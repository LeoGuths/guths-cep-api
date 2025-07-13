using Guths.Cep.Api.Interfaces.Providers;
using Guths.Cep.Api.Interfaces.Refit;
using Guths.Cep.Api.Responses;

namespace Guths.Cep.Api.Services;

public sealed class OpenCepIntegration : IOpenCepIntegration
{
    private readonly IOpenCepIntegrationRefit _openCepIntegrationRefit;
    
    public string ProviderName => "OpenCep";

    public OpenCepIntegration(IOpenCepIntegrationRefit openCepIntegrationRefit)
    {
        _openCepIntegrationRefit = openCepIntegrationRefit;
    }

    public async Task<AddressResponse?> GetAddressAsync(string cep)
    {
        var responseData = await _openCepIntegrationRefit.GetAddressFromOpenCep(cep);

        if (responseData is { IsSuccessStatusCode: true, Content: not null })
        {
            return new AddressResponse(
                ZipCode: responseData.Content.Cep,
                Street: responseData.Content.Logradouro,
                Neighborhood: responseData.Content.Bairro,
                City: responseData.Content.Localidade,
                Uf: responseData.Content.Uf
            );
        }

        return null;
    }
}