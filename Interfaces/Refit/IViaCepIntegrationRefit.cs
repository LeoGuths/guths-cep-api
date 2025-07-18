using Guths.Cep.Api.Responses;
using Refit;

namespace Guths.Cep.Api.Interfaces.Refit;

public interface IViaCepIntegrationRefit
{
    [Get("/ws/{cep}/json")]
    Task<ApiResponse<ViaCepResponse?>> GetAddressFromViaCep(string cep);
}