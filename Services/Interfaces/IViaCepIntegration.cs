using Guths.Cep.Api.Responses;

namespace Guths.Cep.Api.Services.Interfaces;

public interface IViaCepIntegration
{
    Task<ViaCepResponse?> GetAddressFromViaCep(string cep);
}