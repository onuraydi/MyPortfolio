using MyPortfolio.WebApi.Entites.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyPortfolio.WebApi.Services.TokenServices
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
