namespace Guths.Cep.Api.Responses;

public sealed record BrasilAbertoResponse(Meta? Meta, Result Result);

public sealed record Result(
    string Street,
    string? Complement,
    string District,
    string? DistrictId,
    string City,
    string? CityId,
    string? IbgeId,
    string State,
    string StateShortname,
    string Zipcode,
    Coordinates? Coordinates
);

public sealed record Meta(int CurrentPage, int ItemsPerPage, int TotalOfItems, int TotalOfPages);
public sealed record Coordinates(int Latitude, int Longitude);
