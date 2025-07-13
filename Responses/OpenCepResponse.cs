namespace Guths.Cep.Api.Responses;

public sealed record OpenCepResponse(
    string Cep,
    string Logradouro,
    string? Complemento,
    string Bairro,
    string Localidade,
    string Uf,
    string? Ibge
);