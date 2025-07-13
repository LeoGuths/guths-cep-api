namespace Guths.Cep.Api.Responses;

public sealed record AddressResponse(
    string ZipCode,
    string Street,
    string Neighborhood,
    string City,
    string Uf,
    string? State = null
)
{
    public string Provider { get; set; } = null!;
}