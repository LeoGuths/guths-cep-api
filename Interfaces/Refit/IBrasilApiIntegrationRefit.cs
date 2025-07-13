using Guths.Cep.Api.Responses;
using Refit;

namespace Guths.Cep.Api.Interfaces.Refit;

public interface IBrasilApiIntegrationRefit
{
    [Get("/api/cep/v1/{cep}")]
    Task<ApiResponse<BrasilApiResponse?>> GetAddressFromBrasilApi(string cep);
}