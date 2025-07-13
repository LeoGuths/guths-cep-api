using Guths.Cep.Api.Responses;
using Refit;

namespace Guths.Cep.Api.Interfaces.Refit;

public interface IOpenCepIntegrationRefit
{
    [Get("/v1/{cep}")]
    Task<ApiResponse<OpenCepResponse?>> GetAddressFromOpenCep(string cep);
}