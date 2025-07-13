namespace Guths.Cep.Api.Responses;

public sealed record BrasilApiResponse(
    string Cep,
    string State,
    string City,
    string Neighborhood,
    string Street,
    string Service
);