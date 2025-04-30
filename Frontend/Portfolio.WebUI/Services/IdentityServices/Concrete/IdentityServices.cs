using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Portfolio.DtoLayer.PortfolioDtos.LoginDtos;
using Portfolio.WebUI.Services.IdentityServices.Abstract;
using Portfolio.WebUI.Settings;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.Extensions.Logging;
using Duende.IdentityServer.Models;
using Portfolio.WebUI.Models;

namespace Portfolio.WebUI.Services.IdentityServices.Concrete
{
    public class IdentityServices : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ClientSettings _clientSettings;
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly ILogger<IdentityServices> _logger;

        public IdentityServices(HttpClient httpClient, IHttpContextAccessor contextAccessor, IOptions<ClientSettings> clientSettings, IOptions<ServiceApiSettings> serviceApiSettings, ILogger<IdentityServices> logger)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
            _clientSettings = clientSettings.Value;
            _serviceApiSettings = serviceApiSettings.Value;
            _logger = logger;
        }

        public async Task<bool> GetRefreshToken()
        {
            try
            {
                var discoveryEndPoint = await GetDiscoveryDocumentAsync("https://localhost:5001");

                var refreshToken = await _contextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

                var refreshTokenRequest = new RefreshTokenRequest
                {
                    ClientId = _clientSettings.AdminClient.ClientId,
                    ClientSecret = _clientSettings.AdminClient.ClientSecret,
                    GrantType = GrantType.ResourceOwnerPassword,
                    RefreshToken = refreshToken,
                    Address = discoveryEndPoint.TokenEndpoint
                };

                var token = await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest).ConfigureAwait(false);

                await StoreTokensAsync(token);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while refreshing the token.");
                return false;
            }
        }


        public async Task<bool> SignIn(LoginDto loginDto)
        {
            var discoveryEndPoint = await GetDiscoveryDocumentAsync(_serviceApiSettings.IdentityServerUrl);

            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId = _clientSettings.AdminClient.ClientId,
                ClientSecret = _clientSettings.AdminClient.ClientSecret,
                GrantType = GrantType.ResourceOwnerPassword,
                UserName = loginDto.Username,
                Password = loginDto.Password,
                Address = discoveryEndPoint.TokenEndpoint,
            };

            var tokenResponse = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest).ConfigureAwait(false);

            if (tokenResponse.IsError)
            {
                throw new Exception($"Password token request failed: {tokenResponse.Error} | HTTP Response: {tokenResponse.HttpErrorReason} | HTTP Content: {await tokenResponse.HttpResponse.Content.ReadAsStringAsync()}");
            }

            var userInfoRequest = new UserInfoRequest
            {
                Token = tokenResponse.AccessToken,
                Address = discoveryEndPoint.UserInfoEndpoint
            };

            var userValues = await _httpClient.GetUserInfoAsync(userInfoRequest).ConfigureAwait(false);

            var claimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties();
            authenticationProperties.StoreTokens(new List<AuthenticationToken>
            {
                new AuthenticationToken { Name = OpenIdConnectParameterNames.AccessToken, Value = tokenResponse.AccessToken },
                new AuthenticationToken { Name = OpenIdConnectParameterNames.RefreshToken, Value = tokenResponse.RefreshToken },
                new AuthenticationToken { Name = OpenIdConnectParameterNames.ExpiresIn, Value = DateTime.Now.AddSeconds(tokenResponse.ExpiresIn).ToString() }
            });

            authenticationProperties.IsPersistent = false;

            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties).ConfigureAwait(false);

            return true;
        }
        

        private async Task<DiscoveryDocumentResponse> GetDiscoveryDocumentAsync(string address)
        {
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = address,
                Policy = new DiscoveryPolicy { RequireHttps = false }
            }).ConfigureAwait(false);

            if (discoveryEndPoint.IsError)
            {
                throw new Exception("Discovery document retrieval failed: " + discoveryEndPoint.Error);
            }

            return discoveryEndPoint;
        }

        private async Task StoreTokensAsync(TokenResponse token)
        {
            var authenticationToken = new List<AuthenticationToken>
            {
                new AuthenticationToken { Name = OpenIdConnectParameterNames.AccessToken, Value = token.AccessToken },
                new AuthenticationToken { Name = OpenIdConnectParameterNames.RefreshToken, Value = token.RefreshToken },
                new AuthenticationToken { Name = OpenIdConnectParameterNames.ExpiresIn, Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString() }
            };

            var result = await _contextAccessor.HttpContext.AuthenticateAsync().ConfigureAwait(false);
            var properties = result.Properties;
            properties.StoreTokens(authenticationToken);

            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal, properties).ConfigureAwait(false);
        }
    }
}
