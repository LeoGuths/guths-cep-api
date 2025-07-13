namespace Guths.Cep.Api.Responses;

public sealed record ApiCepResponse(
    int Status,
    string Code,
    string State,
    string City,
    string District,
    string Address
);