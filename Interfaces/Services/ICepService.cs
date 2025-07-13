using Guths.Cep.Api.Responses;

namespace Guths.Cep.Api.Interfaces.Services;

public interface ICepService
{
    Task<AddressResponse?> GetAddressAsync(string cep);
}
