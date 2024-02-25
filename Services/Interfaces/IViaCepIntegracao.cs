using Guths.CEP.API.Response;

namespace Guths.CEP.API.Services.Interfaces;

public interface IViaCepIntegracao
{
    Task<ViaCepResponse?> ObterDadosViaCep(string cep);
}