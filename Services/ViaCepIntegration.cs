using Guths.Cep.Api.Refit;
using Guths.Cep.Api.Responses;
using Guths.Cep.Api.Services.Interfaces;

namespace Guths.Cep.Api.Services;

public class ViaCepIntegration : IViaCepIntegration
{
    private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;
    
    public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit)
    {
        _viaCepIntegrationRefit = viaCepIntegrationRefit;
    }

    public async Task<ViaCepResponse?> GetAddressFromViaCep(string cep)
    {
        var responseData = await _viaCepIntegrationRefit.GetAddressFromViaCep(cep);

        return responseData is { IsSuccessStatusCode: true } 
            ? responseData.Content 
            : null;
    }
}