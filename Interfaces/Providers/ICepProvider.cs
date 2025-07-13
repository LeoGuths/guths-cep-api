using Guths.Cep.Api.Responses;

namespace Guths.Cep.Api.Interfaces.Providers;

public interface ICepProvider
{
    string ProviderName { get; }
    Task<AddressResponse?> GetAddressAsync(string cep);
}