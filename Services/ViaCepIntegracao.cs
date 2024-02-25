using Guths.CEP.API.Refit;
using Guths.CEP.API.Response;
using Guths.CEP.API.Services.Interfaces;

namespace Guths.CEP.API.Services;

public class ViaCepIntegracao : IViaCepIntegracao
{
    private readonly IViaCepIntegracaoRefit _viaCepIntegracaoRefit;
    
    public ViaCepIntegracao(IViaCepIntegracaoRefit viaCepIntegracaoRefit)
    {
        _viaCepIntegracaoRefit = viaCepIntegracaoRefit;
    }

    public async Task<ViaCepResponse?> ObterDadosViaCep(string cep)
    {
        var responseData = await _viaCepIntegracaoRefit.ObterDadosViaCep(cep);

        if (responseData is { IsSuccessStatusCode: true })
        {
            return responseData.Content;
        }

        return null;
    }
}