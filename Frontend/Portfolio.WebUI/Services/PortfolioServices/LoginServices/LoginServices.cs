using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Portfolio.DtoLayer.PortfolioDtos.LoginDtos;
using Portfolio.WebUI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace Portfolio.WebUI.Services.PortfolioServices.LoginServices
{
    public class LoginServices : IloginServices
    {
        private readonly HttpClient _httpClient;
        private readonly HttpContext _context;
        public LoginServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:5001/api/Logins", loginDto);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (tokenModel != null)
                {
                    var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();

                    if(tokenModel.Token!= null)
                    {
                        claims.Add(new Claim("PortfolioToken",tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true,
                        };

                        await _context.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                    }
                }
            }
            return response.ToString();
        }
    }
}
