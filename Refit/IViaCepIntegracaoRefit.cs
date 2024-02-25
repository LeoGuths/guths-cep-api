using Guths.CEP.API.Response;
using Refit;

namespace Guths.CEP.API.Refit;

public interface IViaCepIntegracaoRefit
{
    [Get("/ws/{cep}/json")]
    Task<ApiResponse<ViaCepResponse?>> ObterDadosViaCep(string cep);
}