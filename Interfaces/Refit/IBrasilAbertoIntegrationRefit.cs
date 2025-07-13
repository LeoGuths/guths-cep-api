using Guths.Cep.Api.Responses;
using Refit;

namespace Guths.Cep.Api.Interfaces.Refit;

public interface IBrasilAbertoIntegrationRefit
{
    [Get("/v2/zipcode/{cep}")]
    Task<ApiResponse<BrasilAbertoResponse?>> GetAddressFromBrasilAberto(string cep);
}