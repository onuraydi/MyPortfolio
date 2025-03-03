using Duende.IdentityModel.Client;
using Duende.IdentityServer.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Portfolio.WebUI.Services.IdentityServices.Abstract;
using Portfolio.WebUI.Settings;

namespace Portfolio.WebUI.Services.IdentityServices.Concrete
{
        public class ClientCredentialTokenService : IClientCredentialTokenService
        {
            private readonly ServiceApiSettings _serviceApiSettings;
            private readonly HttpClient _httpClient;
            private readonly IMemoryCache _memoryCache;
            private readonly ClientSettings _clientSettings;

            public ClientCredentialTokenService(
                IOptions<ServiceApiSettings> serviceApiSettings,
                HttpClient httpClient,
                IMemoryCache memoryCache,
                IOptions<ClientSettings> clientSettings)
            {
                _serviceApiSettings = serviceApiSettings.Value;
                _httpClient = httpClient;
                _memoryCache = memoryCache;
                _clientSettings = clientSettings.Value;
            }

            public async Task<string> GetToken()
            {
                if (_memoryCache.TryGetValue("PortfolioToken", out string cachedToken))
                {
                    return cachedToken;
                }

                var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
                {
                    Address = "https://localhost:5001",
                });

                var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
                {
                    ClientId = _clientSettings.AdminClient.ClientId,
                    ClientSecret = _clientSettings.AdminClient.ClientSecret,
                    GrantType = GrantType.ResourceOwnerPassword,
                    Address = discoveryEndPoint.TokenEndpoint,
                };

                var newToken = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);

                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(newToken.ExpiresIn)
                };

                _memoryCache.Set("PortfolioToken", newToken.AccessToken, cacheOptions);

                return newToken.AccessToken;
            }
        }
    }
            