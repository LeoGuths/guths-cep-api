using Guths.CEP.API.Services.Interfaces;

namespace Guths.CEP.API.Endpoints;

public static class ViaCepEndpoints
{
    public static void MapViaCepEndpoints(this WebApplication app)
    {
        app.MapGet("{cep}", BuscarDadosEndereco);
    }
    
    public static async Task<IResult> BuscarDadosEndereco(string cep, IViaCepIntegracao viaCepIntegracao)
    {
        var responseData = await viaCepIntegracao.ObterDadosViaCep(cep);

        return responseData is null 
            ? Results.NotFound() 
            : Results.Ok(responseData);
    }
}