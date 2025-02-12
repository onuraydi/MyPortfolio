using Microsoft.AspNetCore.Identity;

namespace MyPortfolio.WebApi.Entites.Identity
{
    public class User: IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpirtTime { get; set; }
    }
}
