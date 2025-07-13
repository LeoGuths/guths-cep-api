using Guths.Cep.Api.Interfaces.Providers;
using Guths.Cep.Api.Interfaces.Refit;
using Guths.Cep.Api.Responses;

namespace Guths.Cep.Api.Services;

public sealed class ApiCepIntegration : IApiCepIntegration
{
    private readonly IApiCepIntegrationRefit _apiCepIntegrationRefit;
    
    public string ProviderName => "ApiCEP";

    public ApiCepIntegration(IApiCepIntegrationRefit apiCepIntegrationRefit)
    {
        _apiCepIntegrationRefit = apiCepIntegrationRefit;
    }

    public async Task<AddressResponse?> GetAddressAsync(string cep)
    {
        var formattedCep = $"{cep[..5]}-{cep.Substring(5, 3)}";
        
        var responseData = await _apiCepIntegrationRefit.GetAddressFromApiCep(formattedCep);

        if (responseData is { IsSuccessStatusCode: true, Content: not null })
        {
            return new AddressResponse(
                ZipCode: responseData.Content.Code.Replace("-", string.Empty),
                Street: responseData.Content.Address,
                Neighborhood: responseData.Content.District,
                City: responseData.Content.City,
                Uf: responseData.Content.State
            );
        }

        return null;
    }
}