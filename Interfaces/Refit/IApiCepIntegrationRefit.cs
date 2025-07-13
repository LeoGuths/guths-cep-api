using Guths.Cep.Api.Responses;
using Refit;

namespace Guths.Cep.Api.Interfaces.Refit;

public interface IApiCepIntegrationRefit
{
    [Get("/file/apicep/{cep}.json")]
    Task<ApiResponse<ApiCepResponse?>> GetAddressFromApiCep(string cep);
}