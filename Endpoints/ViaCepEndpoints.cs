using Guths.Cep.Api.Services.Interfaces;

namespace Guths.Cep.Api.Endpoints;

public static class ViaCepEndpoints
{
    public static void MapViaCepEndpoints(this WebApplication app)
    {
        app.MapGet("{cep}", GetAddress);
    }
    
    public static async Task<IResult> GetAddress(string cep, IViaCepIntegration viaCepIntegration)
    {
        var responseData = await viaCepIntegration.GetAddressFromViaCep(cep);

        return responseData is null 
            ? Results.NotFound() 
            : Results.Ok(responseData);
    }
}