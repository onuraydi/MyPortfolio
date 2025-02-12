namespace MyPortfolio.WebApi.Entites.Identity
{
    public class TokenModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
