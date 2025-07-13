using Guths.Cep.Api.Interfaces.Services;
using Guths.Cep.Api.Responses;

namespace Guths.Cep.Api.Endpoints;

public static class CepEndpoints
{
    public static void MapCepEndpoints(this WebApplication app)
    {
        app.MapGet("/cep/{cep}", GetAddress)
            .WithName("GetAddress")
            .WithSummary("Busca endereço por CEP")
            .WithDescription("Busca informações de endereço utilizando múltiplos provedores com fallback automático")
            .WithOpenApi()
            .Produces<AddressResponse>()
            .Produces(StatusCodes.Status404NotFound);
    }
    
    public static async Task<IResult> GetAddress(string cep, ICepService cepService)
    {
        var cleanCep = new string(cep.Where(char.IsDigit).ToArray());
    
        if (string.IsNullOrWhiteSpace(cleanCep) || cleanCep.Length != 8)
            return Results.BadRequest("CEP está em formato inválido. Deve conter 8 dígitos.");
        
        var responseData = await cepService.GetAddressAsync(cleanCep);

        return responseData is null 
            ? Results.NotFound("CEP não encontrado") 
            : Results.Ok(responseData);
    }
}